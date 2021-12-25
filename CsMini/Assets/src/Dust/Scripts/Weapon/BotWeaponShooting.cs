using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWeaponShooting : MonoBehaviour
{

    [SerializeField] private GameObject bloodPS = null;
    private Transform player;
    private float lastShootTime = 0;

    private bool canShoot = true;

    private int primaryCurrentAmmo;
    private int primaryCurrentAmmoStorage;

    private int secondaryCurrentAmmo;
    private int secondaryCurrentAmmoStorage;

    private bool primaryMagazineIsEmpty = false;
    private bool secondaryMagazineIsEmpty = false;
    private bool canReload = true;

    private BotInventory inventory;
    private BotEquipmentManager manager;
    private PlayerHUD playerHUD;
    private PlayerState botState;
    [SerializeField] private Transform weaponHolderR;
    private AudioSource audioSourceFire;

    private void Start()
    {
        getReferences();
    }


    private void RaycastShoot(Weapon currentWeapon)
    {
        RaycastHit hit;
        Debug.DrawRay(weaponHolderR.position, weaponHolderR.TransformDirection(Vector3.up) * 5f, Color.red);

        if (Physics.Raycast(weaponHolderR.position, weaponHolderR.TransformDirection(Vector3.up), out hit, currentWeapon.range))
        {
            if (hit.transform.tag == "Player")
            {
                PlayerState playerState = hit.transform.GetComponent<PlayerState>();
                playerState.takeDamage(currentWeapon.damage / 2);

                spawnBloodParticles(hit.point, hit.normal);

                if (playerState.isDie())
                {
                    // playerHUD.updateKill(botState.getPlayerName(), playerState.getPlayerName());
                    GlobalState.restartGame();
                }
            }
        }

        if (currentWeapon.weaponStyle != WeaponStyle.Melee)
            Instantiate(currentWeapon.muzzleFlashParticles, manager.currentWeaponBarrel);
    }



    public void shoot()
    {
        Weapon currentWeapon = inventory.getItem(manager.currentlyEquippedWeapon);

        if (currentWeapon == null)
            return;

        int slot = (int)currentWeapon.weaponStyle;

        canShoot = !((slot == 0 && primaryMagazineIsEmpty) || (slot == 1 && secondaryMagazineIsEmpty));


        if (canShoot && canReload)
        {


            if (Time.time > lastShootTime + (currentWeapon.fireRate * 2))
            {
                lastShootTime = Time.time;
                RaycastShoot(currentWeapon);
                useAmmo(slot, 1, 0);


                ///audio not set or weapon without sound
                if (currentWeapon.FireClip == null)
                    return;

                if (audioSourceFire.isPlaying)
                    audioSourceFire.Stop();

                audioSourceFire.PlayOneShot(currentWeapon.FireClip, 0.6f);
            }
        }

    }

    private void useAmmo(int slot, int currentAmmoUsed, int currentStoreAmmoUsed)
    {
        if (slot == 0)
        {
            primaryCurrentAmmo -= currentAmmoUsed;
            primaryCurrentAmmoStorage -= currentStoreAmmoUsed;
            if (primaryCurrentAmmo <= 1)
            {
                primaryMagazineIsEmpty = true;
                reload(slot);
            }
        }
        else if (slot == 1)
        {
            secondaryCurrentAmmo -= currentAmmoUsed;
            secondaryCurrentAmmoStorage -= currentStoreAmmoUsed;
            if (secondaryCurrentAmmo <= 0)
            {
                secondaryMagazineIsEmpty = true;
                reload(slot);
            }
        }
    }


    private void reload(int slot)
    {
        Weapon weapon = inventory.getItem(slot);

        if (weapon == null)
            return;

        int magazineSize = weapon.magazineSize;
        if (slot == 0)
        {
            if (!((primaryCurrentAmmo != magazineSize) && (primaryCurrentAmmo >= 0 && primaryCurrentAmmoStorage > 0)))
                return;

            int subAmmo = Mathf.Min(magazineSize, primaryCurrentAmmoStorage);


            primaryCurrentAmmoStorage = Mathf.Max(primaryCurrentAmmoStorage - (magazineSize - primaryCurrentAmmo), 0);

            primaryCurrentAmmo = subAmmo;

            primaryMagazineIsEmpty = false;
        }
        else if (slot == 1)
        {
            if (!((secondaryCurrentAmmo != magazineSize) && (secondaryCurrentAmmo >= 0 && secondaryCurrentAmmoStorage > 0)))
                return;

            int subAmmo = Mathf.Min(magazineSize, secondaryCurrentAmmoStorage + secondaryCurrentAmmo);

            secondaryCurrentAmmoStorage = Mathf.Max(secondaryCurrentAmmoStorage - (magazineSize - secondaryCurrentAmmo), 0);

            secondaryCurrentAmmo = subAmmo;

            secondaryMagazineIsEmpty = false;
        }
    }


    public void initAmmo(int slot, Weapon weapon)
    {
        if (!canReload)
            return;

        if (slot == 0)
        {
            primaryCurrentAmmo = weapon.magazineSize;
            primaryCurrentAmmoStorage = weapon.storedAmmo;
        }
        else if (slot == 1)
        {
            secondaryCurrentAmmo = weapon.magazineSize;
            secondaryCurrentAmmoStorage = weapon.storedAmmo;
        }
    }


    private void spawnBloodParticles(Vector3 position, Vector3 normal)
    {
        Instantiate(bloodPS, position, Quaternion.FromToRotation(Vector3.up, normal));
    }

    private void getReferences()
    {
        inventory = GetComponent<BotInventory>();
        manager = GetComponent<BotEquipmentManager>();
        playerHUD = GetComponent<PlayerHUD>();
        audioSourceFire = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player").transform;
    }
}

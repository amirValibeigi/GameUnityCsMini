using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{

    private EquipmentManager equipmentManager;
    private Inventory inventory;
    private WeaponShooting weaponShooting;
    private AudioSource audioSource;


    private void Start()
    {
        getReferences();
    }

    public void destroyWeapon()
    {
        Destroy(equipmentManager.currentWeaponObject);
    }

    public void instantiateWeapon()
    {
        Weapon weapon = inventory.getItem(equipmentManager.currentlyEquippedWeapon);

        if (weapon == null)
            return;

        equipmentManager.currentWeaponObject = Instantiate(weapon.prefab, equipmentManager.WeaponHolderR);

        equipmentManager.currentWeaponBarrel = equipmentManager.currentWeaponObject.transform.GetChild(0);

        equipmentManager.currentWeaponAnimator = equipmentManager.currentWeaponObject.GetComponent<Animator>();
        weaponShooting.setAudioClipFire(weapon.FireClip);
    }

    public void weaponPreload()
    {
        weaponShooting.weaponLoaded = false;
    }

    public void weaponLoaded()
    {
        weaponShooting.weaponLoaded = true;
    }


    public void startReload()
    {
        weaponShooting.canReload = false;
        Weapon weapon = inventory.getItem(equipmentManager.currentlyEquippedWeapon);
        audioSource.PlayOneShot(weapon.ReloadClip, 0.4f);
    }

    public void endReload()
    {
        weaponShooting.canReload = true;
    }

    private void getReferences()
    {
        inventory = GetComponentInParent<Inventory>();
        equipmentManager = GetComponentInParent<EquipmentManager>();
        weaponShooting = GetComponentInParent<WeaponShooting>();
        audioSource = GetComponentInParent<AudioSource>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentlyEquippedWeapon = 2;
    public GameObject currentWeaponObject = null;
    public Transform currentWeaponBarrel = null;
    public Transform WeaponHolderR;
    [SerializeField] Weapon defaultMeleeWeapon = null;
    [SerializeField] Weapon defaultPistolWeapon = null;
    public Animator currentWeaponAnimator;
    private Animator playerAnimator;
    private Inventory inventory;
    private PlayerHUD playerHUD;

    private void Start()
    {
        getReferences();
        StartCoroutine(initVariables());
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquippedWeapon != 0)
        {
            chooseWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentlyEquippedWeapon != 1)
        {
            chooseWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currentlyEquippedWeapon != 2)
        {
            chooseWeapon(2);
        }
    }


    private void equipWeapon(Weapon weapon)
    {
        if (weapon == null)
            return;

        currentlyEquippedWeapon = (int)weapon.weaponStyle;
        playerAnimator.SetInteger("weaponType", (int)weapon.weaponType);
        playerHUD.updateWeaponUI(weapon);
    }


    private void unequipWeapon()
    {
        playerAnimator.SetTrigger("unequipWeapon");
    }


    private void chooseWeapon(int type)
    {

        unequipWeapon();
        equipWeapon(inventory.getItem(type));
    }

    private IEnumerator initVariables()
    {
        yield return new WaitForSeconds(0.5f);

        inventory.addItem(defaultMeleeWeapon);
        inventory.addItem(defaultPistolWeapon);
        unequipWeapon();
        equipWeapon(inventory.getItem(2));
    }
    private void getReferences()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
        playerHUD = GetComponent<PlayerHUD>();
    }

    public void onClickPrimary()
    {
        chooseWeapon(0);
    }

    public void onClickSecondary()
    {
        chooseWeapon(1);
    }

    public void onClickMelee()
    {
        chooseWeapon(2);
    }
}

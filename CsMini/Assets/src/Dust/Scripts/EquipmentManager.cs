using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentlyEquippedWeapon = 2;
    public GameObject currentWeaponObject = null;
    public Transform WeaponHolderR;
    [SerializeField] Weapon defaultMeleeWeapon = null;
    private Animator animator;
    private Inventory inventory;

    private void Start()
    {
        getReferences();
        StartCoroutine(initVariables());
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquippedWeapon != 0)
        {
            unequipWeapon();
            equipWeapon(inventory.getItem(0));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentlyEquippedWeapon != 1)
        {
            unequipWeapon();
            equipWeapon(inventory.getItem(1));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currentlyEquippedWeapon != 2)
        {
            unequipWeapon();
            equipWeapon(inventory.getItem(2));
        }
    }


    private void equipWeapon(Weapon weapon)
    {
        if (weapon == null)
            return;

        currentlyEquippedWeapon = (int)weapon.weaponStyle;
        animator.SetInteger("weaponType", (int)weapon.weaponType);
    }


    private void unequipWeapon()
    {
        animator.SetTrigger("unequipWeapon");
    }


    private IEnumerator initVariables()
    {
        yield return new WaitForSeconds(2);

        inventory.addItem(defaultMeleeWeapon);
        unequipWeapon();
        equipWeapon(inventory.getItem(2));
    }
    private void getReferences()
    {
        animator = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }
}

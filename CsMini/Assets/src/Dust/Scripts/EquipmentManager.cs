using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    private Animator animator;
    private Inventory inventory;

    private void Strart()
    {
        getReferences();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            setWeaponAnimations(0, WeaponType.AR);
            setWeaponAnimations(0, WeaponType.Shotgun);
            setWeaponAnimations(0, WeaponType.Sniper);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            setWeaponAnimations(1, WeaponType.Pistol);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            setWeaponAnimations(2, WeaponType.Melee);
        }
    }

    private void setWeaponAnimations(int weaponStyle, WeaponType weaponType)
    {
        Weapon weapon = inventory.getItem(weaponStyle);

        if (weapon != null && weapon.weaponType == weaponType)
        {
            animator.SetInteger("weaponType", (int)weaponType);
        }
    }

    private void getReferences()
    {
        animator = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }
}

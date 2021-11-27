using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private Weapon[] weapons;

    private WeaponShooting weaponShooting;

    private void Start()
    {
        getReferences();
        initVarables();
    }


    public void addItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;
        if (weapons[newItemIndex] != null)
        {
            removeItem(newItemIndex);
        }

        weapons[newItemIndex] = newItem;
        weaponShooting.initAmmo((int)newItem.weaponStyle, newItem);
    }

    public void removeItem(int index)
    {
        weapons[index] = null;
    }


    public Weapon getItem(int index)
    {
        return weapons[index];
    }


    private void getReferences()
    {
        weaponShooting = GetComponent<WeaponShooting>();
    }

    private void initVarables()
    {
        weapons = new Weapon[3];
    }
}

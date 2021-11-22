using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private Weapon[] weapons;

    private PlayerHUD playerHUD;


    private void Start()
    {
        getReferences();
        initVarables();
    }


    public void addItem(Weapon newItem)
    {
        weapons[(int)newItem.weaponStyle] = newItem;

        playerHUD.updateWeaponUI(newItem);
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
        playerHUD = GetComponent<PlayerHUD>();
    }

    private void initVarables()
    {
        weapons = new Weapon[3];
    }
}

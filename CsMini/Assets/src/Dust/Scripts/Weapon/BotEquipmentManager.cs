using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotEquipmentManager : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] public Transform WeaponHolderR;

    [Header("Weapon")]
    [SerializeField] private Weapon defaultMeleeWeapon = null;
    [SerializeField] private Weapon defaultPistolWeapon = null;
    [SerializeField] private Weapon defaultPrimaryWeapon = null;
    public int currentlyEquippedWeapon = 2;
    public GameObject currentWeaponObject = null;
    public Transform currentWeaponBarrel = null;
    public BotInventory inventory;

    private void Start()
    {
        getReferences();
        StartCoroutine(initVariables());
    }

    private void Update()
    {

    }


    private void equipWeapon(Weapon weapon)
    {
        if (weapon == null)
            return;

        currentlyEquippedWeapon = (int)weapon.weaponStyle;

        currentWeaponObject = Instantiate(weapon.prefab, WeaponHolderR);

        currentWeaponBarrel = currentWeaponObject.transform.GetChild(0);
    }

    private IEnumerator initVariables()
    {
        yield return new WaitForSeconds(0.5f);
        inventory.addItem(defaultMeleeWeapon);
        inventory.addItem(defaultPistolWeapon);
        inventory.addItem(defaultPrimaryWeapon);
        equipWeapon(inventory.getItem(0));
    }
    private void getReferences()
    {
        inventory = GetComponent<BotInventory>();
    }
}

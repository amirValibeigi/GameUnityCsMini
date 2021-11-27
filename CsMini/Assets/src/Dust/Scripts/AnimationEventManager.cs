using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{

    private EquipmentManager equipmentManager;
    private Inventory inventory;


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
    }


    private void getReferences()
    {
        inventory = GetComponentInParent<Inventory>();
        equipmentManager = GetComponentInParent<EquipmentManager>();
    }
}

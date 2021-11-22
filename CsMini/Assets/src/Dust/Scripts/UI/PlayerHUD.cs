using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Text txHealth;
    [SerializeField] private WeaponUI weaponUI;


    public void updateHealth(int health)
    {
        txHealth.text = health.ToString();
    }


    public void updateWeaponUI(Weapon weapon)
    {
        weaponUI.updateInfo(weapon.icon, weapon.magazineSize, weapon.magazineCount);
    }
}

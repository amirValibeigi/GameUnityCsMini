using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{

    [Header("Text UI")]
    [SerializeField] private Text txHealth;
    [SerializeField] private Text txNameKill;

    [Header("Other")]
    [SerializeField] private WeaponUI weaponUI;

    private float removeTextNameKill;


    public void Update()
    {
        if (removeTextNameKill <= Time.deltaTime && txNameKill.text.Length != 0)
        {
            txNameKill.text = "";
        }
    }

    public void updateHealth(int health)
    {
        txHealth.text = health.ToString();
    }


    public void updateWeaponUI(Weapon weapon)
    {
        weaponUI.updateInfo(weapon.icon, weapon.magazineSize, weapon.storedAmmo);
    }

    public void updateAmmoUI(int currentAmmo, int storedAmmo)
    {
        weaponUI.updateAmmoUI(currentAmmo, storedAmmo);
    }


    public void updateKill(string name, string killed)
    {
        txNameKill.text = killed + " killed by " + name;
        removeTextNameKill = Time.deltaTime + 2;
    }
}

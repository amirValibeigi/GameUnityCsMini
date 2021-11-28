using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Text storedAmmoText;


    public void updateInfo(Sprite weaponIcon, int currentAmmo, int storedAmmo)
    {
        iconImage.sprite = weaponIcon;
        updateAmmoUI(currentAmmo, storedAmmo);
    }

    public void updateAmmoUI(int currentAmmo, int storedAmmo)
    {

        storedAmmoText.text = currentAmmo.ToString() + "/" + storedAmmo.ToString();
    }
}

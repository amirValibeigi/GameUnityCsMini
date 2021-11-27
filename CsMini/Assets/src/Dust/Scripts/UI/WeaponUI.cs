using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Text storedAmmoText;


    public void updateInfo(Sprite weaponIcon, int magazineSize, int storedAmmo)
    {
        iconImage.sprite = weaponIcon;
        storedAmmoText.text = magazineSize.ToString() + "/" + storedAmmo.ToString();
    }
}

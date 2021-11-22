using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Text magazineText;


    public void updateInfo(Sprite weaponIcon, int magazineSize, int magazineCount)
    {
        iconImage.sprite = weaponIcon;
        magazineText.text = magazineSize.ToString() + "/" + (magazineSize * magazineCount).ToString();
    }
}

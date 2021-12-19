using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{

    public GameObject prefab;
    public GameObject muzzleFlashParticles;
    public int damage;
    public int magazineSize;
    public int storedAmmo;
    public float range;
    public float fireRate;
    public WeaponType weaponType;
    public WeaponStyle weaponStyle;

}

public enum WeaponType { Melee, Pistol, AR, Shotgun, Sniper }
public enum WeaponStyle { Primary, Secondary, Melee }
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectContanier;

    [SerializeField] Weapondata startingWeapon;

    List<WeaponBase> weapons;
    private void Awake()
    {
        weapons = new List<WeaponBase>();
    }
    private void Start()
    {
        AddWeapon(startingWeapon);
    }
    public void AddWeapon(Weapondata weapondata)
    {
        GameObject weaponGameObject = Instantiate(weapondata.weaponBasePrefab, weaponObjectContanier);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();
        
        weaponBase.SetData(weapondata);
        weapons.Add(weaponBase);

        Level level = GetComponent<Level>();
        if(level != null)
        {
            level.AddUpradesIntoTheListOfAvailableUpgrade(weapondata.upgrades);
        }
    }

    public void UpgradeWeapon(UpgradeData upgradeData)
    {
       WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weapondata == upgradeData.weaponData);
       weaponToUpgrade.Upgrade(upgradeData);
    }
}
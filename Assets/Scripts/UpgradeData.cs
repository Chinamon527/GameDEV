using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponGet,
    ItemGet
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType UpgradeType;
    public string Name;
    public Sprite icon;

    public Weapondata weaponData;
    public WeaponStats weaponUpgradeStats;

    public Item item;
    public ItemStats ItemStats;
}

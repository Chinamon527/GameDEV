using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public int numberOfAttack;

    public WeaponStats(int damage,float timeToAttack, int numberOfAttack)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttack = numberOfAttack;
    }

    internal void Sum(WeaponStats weaponUpgradeStast)
    {
        this.damage += weaponUpgradeStast.damage;
        this.timeToAttack += weaponUpgradeStast.timeToAttack;
        this.numberOfAttack += weaponUpgradeStast.numberOfAttack;
    }
}

[CreateAssetMenu]
public class Weapondata : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
    
}

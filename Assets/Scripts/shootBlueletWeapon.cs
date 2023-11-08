using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBlueletWeapon : WeaponBase
{
    Playermove Playermove;

    [SerializeField] GameObject BlueletPrefab;
    [SerializeField] float spread = 0.5f;

    private void Awake()
    {
        Playermove = GetComponentInParent<Playermove>();
    }

    public override void Attack()
    {

        for(int i=0; i < weaponStats.numberOfAttack; i++)
        {
            GameObject shootBluelet = Instantiate(BlueletPrefab);
            
            Vector3 newblueletpostion = transform.position;
            if(weaponStats.numberOfAttack > 1)
            {
                newblueletpostion.y -= (spread * (weaponStats.numberOfAttack-1)) / 2; //calculating offset
                newblueletpostion.y += i * spread;//spreading the bluelet along the line
            }

            shootBluelet.transform.position = newblueletpostion;


            shootBlueletProjectile shootBlueletProjectile = shootBluelet.GetComponent<shootBlueletProjectile>();
            shootBlueletProjectile.SetDirection(Playermove.lastHorizontalVector, 0f);
            shootBlueletProjectile.damage = weaponStats.damage;
        }
    }
} 

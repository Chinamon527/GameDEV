using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{   
    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    Playermove playermove;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);
    private void Awake()
    {
        playermove = GetComponentInParent<Playermove>();
    }


    private void ApplyDamege(Collider2D[] colliders)
    {
        for (int i= 0; i< colliders.Length; i++)
        {
            Damageable e = colliders[i].GetComponent<Damageable>();
            if(e != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }   
        }
    }

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }
    IEnumerator AttackProcess()
    {
        for(int i = 0; i < weaponStats.numberOfAttack; i++)
        {
            if (playermove.lastHorizontalVector > 0)
            {
                rightWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
                ApplyDamege(colliders);
            }
            else
            {
                leftWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
                ApplyDamege(colliders);
            }
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}

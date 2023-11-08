using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    public int hp = 999;
    public int damage = 1;
    public int experience_reward = 400;
    public float movespeed = 1f;
    public EnemyStats stats;

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.experience_reward = stats.experience_reward;
        this.movespeed = stats.movespeed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}
public class Enemy : MonoBehaviour , Damageable
{
    Transform targetDestination;
    GameObject targetGameobject;
    Character targetCharacter;

    Rigidbody2D rgdbd2d;

    public EnemyStats stats;
    
    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }
    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }
    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * stats.movespeed;
    }

    internal void UpdateStatsForProgess(float progress)
    {
        stats.ApplyProgress(progress);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    internal void Setstats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<Character>();
        }

        targetCharacter.TakeDamege(stats.damage);
    }

    public void TakeDamage(int damage)
    {
        stats.hp -= damage;

        if(stats.hp < 1)
        {
            targetGameobject.GetComponent<Level>().AddExperience(stats.experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }
}

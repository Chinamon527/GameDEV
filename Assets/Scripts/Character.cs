using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;

    public int armor = 0;
    public float hpRegenerationRate = 1f;
    public float hpRegenerationTime;


    [SerializeField] statusBar hpBar;


    [HideInInspector] public Level level;
    private bool isDead;

    private void Awake()
    {
        level = GetComponent<Level>();
    }
    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
    }

    private void Update()
    {
        hpRegenerationTime += Time.deltaTime * hpRegenerationRate;

        if (hpRegenerationTime > 1f)
        {
            Heal(1);
            hpRegenerationTime -= 1f;
        }
    }
    public void TakeDamege(int damage)
    {
        ApplyArmor(ref damage);

        if(isDead == true) { return; }
        currentHp -= damage;

        if(currentHp <= 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0) { damage = 0; }
    }

    public void Heal(int amount) {
        if(currentHp <=0) { return; }

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }
}

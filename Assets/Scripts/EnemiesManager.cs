using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] StageProgress stageProgress;
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    GameObject player;

    List<Enemy> bossEnemiesList;
    int totalBossHealth;
    int currentBossHelth;
    [SerializeField] Slider bossHealthBar;

    private void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;
        bossHealthBar = FindObjectOfType<BossHPBar>().GetComponent<Slider>();
    }
    private void Update()
    {
        UpdateBossHealth();
    }
    private void UpdateBossHealth()
    {
        if(bossEnemiesList == null) { return; }
        if(bossEnemiesList.Count == 0) { return; }

        currentBossHelth = 0;

        for(int i = 0; i < bossEnemiesList.Count; i++)
        {
            if(bossEnemiesList[i] == null) { continue; }
            currentBossHelth += bossEnemiesList[i].stats.hp;
        }
        bossHealthBar.value = currentBossHelth;
    }
    public void SpawnEnemy(EnemyData enemyToSpawn, bool isBoss)
    {
        Vector3 position = UtillityTools.GenerateRandomPositionSquarPattern(spawnArea);

        // Check if the position is too close to the player
        float minDistanceToPlayer = 3.0f; // You can adjust this distance as needed
        while (Vector3.Distance(position, player.transform.position) < minDistanceToPlayer)
        {
            position = UtillityTools.GenerateRandomPositionSquarPattern(spawnArea); // Regenerate a new position
        }

        // main enemy object
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;

        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.SetTarget(player);
        newEnemyComponent.Setstats(enemyToSpawn.stats);
        newEnemyComponent.UpdateStatsForProgess(stageProgress.Progress);

        if(isBoss == true)
        {
            SpawnBossEnemy(newEnemyComponent);
        }

        newEnemy.transform.parent = transform;

        //sprite
        GameObject spriteObject = Instantiate(enemyToSpawn.anitionPrefub);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = Vector3.zero;
    }

    private void SpawnBossEnemy(Enemy newBoss)
    {
        if(bossEnemiesList == null) { bossEnemiesList = new List<Enemy>(); }

        bossEnemiesList.Add(newBoss);
        totalBossHealth += newBoss.stats.hp;

        bossHealthBar.maxValue = totalBossHealth;
    }
}

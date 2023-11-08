using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] Stagedata stagedata;
    [SerializeField] EnemiesManager EnemiesManager;
    
    StageTime stageTime;
    int eventIndexer;
    PlayerWinManager playerWin;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }
    private void Start()
    {
        playerWin = FindObjectOfType<PlayerWinManager>();
    }
    private void Update()
    {
        if(eventIndexer >= stagedata.stageEvents.Count) { return; }

        if (stageTime.time > stagedata.stageEvents[eventIndexer].time)
        {
            switch (stagedata.stageEvents[eventIndexer].eventType)
            {
                case stageEventType.SpawnEnemy:
                    SpawnEnemy(false);
                    break;
                case stageEventType.SpawnObject:
                    for (int i = 0; i < stagedata.stageEvents[eventIndexer].count; i++)
                    {
                        SpawnObject();
                    }
                    break;

                case stageEventType.WinStage:
                    WinStage();
                    break;

                case stageEventType.SpawnEnemyBoss:
                    SpawnEnemyBoss();
                    break;
            }

            Debug.Log(stagedata.stageEvents[eventIndexer].message);
            eventIndexer += 1;
        }
    }

    private void SpawnEnemyBoss()
    {
        SpawnEnemy(true);
    }

    private void WinStage()
    {
        playerWin.Win();
    }

    private void SpawnEnemy(bool bossEnemy)
    {
        for (int i = 0; i < stagedata.stageEvents[eventIndexer].count; i++)
        {
            EnemiesManager.SpawnEnemy(stagedata.stageEvents[eventIndexer].enemyToSpawn, bossEnemy);
        }
    }

    private void SpawnObject()
    {
        Vector3 positionToSpawn = GameManager.instance.playerTransform.position;
        positionToSpawn += UtillityTools.GenerateRandomPositionSquarPattern(new Vector2(5f, 5f));
        
        SpawnManager.instance.Spawnobject(
            positionToSpawn,
            stagedata.stageEvents[eventIndexer].objectToSpawn
            );
    }
}

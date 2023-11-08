using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum stageEventType
{
    SpawnEnemy,
    SpawnEnemyBoss,
    SpawnObject,
    WinStage
}


[Serializable]
public class StageEvent
{
    public stageEventType eventType;
    public float time;
    public string message;

    public EnemyData enemyToSpawn;
    public GameObject objectToSpawn;
    public int count;
}

[CreateAssetMenu]
public class Stagedata : ScriptableObject
{
   public List<StageEvent> stageEvents;
}

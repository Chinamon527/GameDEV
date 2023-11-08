using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManeger pauseManeger;

    [SerializeField] GameWinPanel levelCompletePanel;
    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        pauseManeger = FindObjectOfType<PauseManeger>();
        levelCompletePanel = FindObjectOfType<GameWinPanel>(true);
    }

    private void Update()
    {
        if(stageTime.time > timeToCompleteLevel)
        {
            pauseManeger.PauseGame();
            levelCompletePanel.gameObject.SetActive(true);
        }
    }
}

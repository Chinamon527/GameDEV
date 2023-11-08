using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinManager : MonoBehaviour
{
    [SerializeField] GameObject winMessafePanel;
    PauseManeger pauseManeger;

    private void Start()
    {
        pauseManeger = GetComponent<PauseManeger>();
    }

    public void Win()
    {
        winMessafePanel.SetActive(true);
        pauseManeger.PauseGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void GameOver()
    {
        Debug.Log("GameOver");
        GetComponent<Playermove>().enabled = false;
        gameOverPanel.SetActive(true);
    }
}

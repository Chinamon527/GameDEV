using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject panel;
    PauseManeger PauseManeger;

    private void Awake()
    {
        PauseManeger = GetComponent<PauseManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeInHierarchy == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void CloseMenu()
    {
        PauseManeger.UnPauseGame();
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        PauseManeger.PauseGame();
        panel.SetActive(true);
    }
}

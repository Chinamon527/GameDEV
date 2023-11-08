using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManeger PauseManeger;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    private void Awake()
    {
        PauseManeger = GetComponent<PauseManeger>();
    }


    private void Start()
    {
        Hidebuttons();
    }

    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        Clean();
        PauseManeger.PauseGame();
        panel.SetActive(true);
        
        for(int i = 0; i< upgradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }

    }

    public void Clean()
    {
        for(int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }
    public void Upgrade(int pressedButtonID)
    {
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressedButtonID);
        ClosePanel();
    }

    public void ClosePanel()
    {
        Hidebuttons();

        PauseManeger.UnPauseGame();
        panel.SetActive(false);
    }

    private void Hidebuttons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }
}

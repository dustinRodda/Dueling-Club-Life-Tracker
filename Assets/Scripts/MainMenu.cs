using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject playerInputPanel;
    public GameObject howToPlayPanel;

    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void PlayerNumberButtonClicked()
    {
        playerInputPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void HowToPlayButtonClicked()
    {
        howToPlayPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReopenMainMenu()
    {
        gameObject.SetActive(true);
    }
}

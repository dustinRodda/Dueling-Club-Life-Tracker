using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPage : MonoBehaviour
{
    public GameObject firstPage;
    public GameObject previousPage;
    public GameObject nextPage;
    public GameObject MainMenu;

    public void BackButtonClicked()
    {
        previousPage.SetActive(true);
        gameObject.SetActive(false);
    }

    public void NextButtonClicked()
    {
        nextPage.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitButtonClicked()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
        firstPage.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}

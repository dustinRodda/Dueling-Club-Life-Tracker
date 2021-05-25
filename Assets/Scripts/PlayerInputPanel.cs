using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputPanel : MonoBehaviour
{
    public GameObject lifeTotalPanel;
    public GameObject playerNamePrefab;
    public List<InputField> playerNameInputs;

    private int numberOfPlayers;

    public void PlayerNumberButtonClicked(int playerNumber)
    {
        numberOfPlayers = playerNumber;

        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject playerNameInput = Instantiate(playerNamePrefab, gameObject.transform);
            playerNameInput.GetComponent<RectTransform>().localPosition = new Vector3(0, 600 - (i * 350), 0);
            playerNameInputs.Add(playerNameInput.transform.Find("InputField").GetComponent<InputField>());
        }
    }

    public void ReadyButtonClicked()
    {
        PlayerLayout playerLayout = lifeTotalPanel.GetComponent<PlayerLayout>();

        lifeTotalPanel.SetActive(true);

        playerLayout.SetNumberOfPlayers(numberOfPlayers);
        playerLayout.GetPlayerNames(playerNameInputs);

        foreach(InputField input in playerNameInputs)
        {
            Destroy(input.transform.parent.gameObject);
        }

        playerNameInputs.Clear();

        gameObject.SetActive(false);
    }
}

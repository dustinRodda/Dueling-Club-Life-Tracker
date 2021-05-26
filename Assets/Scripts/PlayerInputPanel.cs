using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputPanel : MonoBehaviour
{
    public GameObject lifeTotalPanel;
    public GameObject playerNamePrefab;

    private List<InputField> playerNameInputs = new List<InputField>();
    private int numberOfPlayers;
    private int[] yPositions = new int[] { -640, -940, -1240, -1540, -1840 };

    public void PlayerNumberButtonClicked(int playerNumber)
    {
        numberOfPlayers = playerNumber;

        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject playerNameInput = Instantiate(playerNamePrefab, gameObject.transform);
            playerNameInput.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, yPositions[i], 0);
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

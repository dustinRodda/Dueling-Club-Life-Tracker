using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLayout : MonoBehaviour
{
    public GameObject playerPrefab;
    public Text timer;

    private int numberOfPlayers;
    private List<Player> players = new List<Player>();
    private List<string> playerNames = new List<string>();
    private int[][] positions;
    private int[] widths;
    private int totalSeconds;
    private bool isTimerOn = false;
    private Color32[] backgroundColors;
    private string[] defaultNames;

    private void Awake()
    {
        positions = new int[4][];
        positions[0] = new int[] { 700, -700 };
        positions[1] = new int[] { 934, 0, -934 };
        positions[2] = new int[] { 1050, 350, -350, -1050 };
        positions[3] = new int[] { 1140, 570, 0, -570, -1140};

        backgroundColors = new Color32[5];
        backgroundColors[0] = new Color32(116, 0, 1, 255);
        backgroundColors[1] = new Color32(26, 72, 43, 255);
        backgroundColors[2] = new Color32(33, 47, 90, 255);
        backgroundColors[3] = new Color32(254, 180, 0, 255);
        backgroundColors[4] = new Color32(0, 0, 0, 255);

        widths = new int[] { 500, 500, 250, 125};

        defaultNames = new string[] { "Harry", "Draco", "Luna", "Cedric", "Tom" };
    }

    public void SetNumberOfPlayers(int number)
    {
        numberOfPlayers = number;
    }

    public void GetPlayerNames(List<InputField> nameInputs)
    {
        if(playerNames.Count > 0)
        {
            playerNames.Clear();
        }

        for (int i = 0; i < nameInputs.Count; i++)
        {
            if (nameInputs[i].text.Length == 0)
            {
                playerNames.Add(defaultNames[i]);
            }
            else
            {
                playerNames.Add(nameInputs[i].text);
            }
        }
    }

    private void CreatePlayer(string name, int index)
    {
        GameObject playerObject = Instantiate(playerPrefab, transform);
        Player player = playerObject.GetComponent<Player>();
        RectTransform playerRect = player.GetComponent<RectTransform>();
        playerRect.localPosition = new Vector3(-175, positions[numberOfPlayers - 2][index], 0);
        playerRect.sizeDelta = new Vector2(widths[numberOfPlayers - 2], 100);
        Image playerBackground = playerObject.transform.Find("Background").GetComponent<Image>();
        playerBackground.color = backgroundColors[index];
        player.Create(name);
        players.Add(player);
    }

    public void ReadyButtonClicked()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            CreatePlayer(playerNames[i], i);
        }

        isTimerOn = true;
        StartCoroutine("StartTimer");
    }

    public void BackButtonClicked()
    {
        isTimerOn = false;
        ResetTimer();
        StopCoroutine("StartTimer");

        foreach(Player player in players)
        {
            Destroy(player.gameObject);
        }

        players.Clear();

        playerNames.Clear();

        numberOfPlayers = 0;

        gameObject.SetActive(false);
    }

    public void ResetButtonClicked()
    {
        ResetTimer();

        foreach (Player player in players)
        {
            player.Reset();
        }
    }

    public void ToggleTimer()
    {
        isTimerOn = !isTimerOn;
    }

    private void ResetTimer()
    {
        totalSeconds = 0;
        timer.text = "00:00";
    }

    private IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (isTimerOn)
            {
                totalSeconds++;

                timer.text = BuildTimerString();
            }
        }
    }

    private string BuildTimerString()
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds - (minutes * 60);
        string minuteString = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
        string secondsString = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

        return minuteString + ":" + secondsString;
    }
}

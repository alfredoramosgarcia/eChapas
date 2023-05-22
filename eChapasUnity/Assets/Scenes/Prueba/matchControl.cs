using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class matchControl : MonoBehaviour
{
    public float matchDuration = 90f; // Total match duration in seconds
    public TextMeshProUGUI teamAGoalsText; // TextMeshProUGUI to display goals for Team A
    public TextMeshProUGUI teamBGoalsText; // TextMeshProUGUI to display goals for Team B
    public TextMeshProUGUI remainingTimeText; // TextMeshProUGUI to display remaining time
    public List<Sprite> teamShields;
    public Image teamShieldImage1;
    public Image teamShieldImage2;

    private float remainingTime; // Remaining time in the match
    private int teamAGoals = 0; // Goals for Team A
    private int teamBGoals = 0; // Goals for Team B

    private void Start()
    {
        remainingTime = matchDuration;
        teamShieldImage1.sprite = teamShields[PlayerPrefs.GetInt("team1")];
        teamShieldImage2.sprite = teamShields[PlayerPrefs.GetInt("team2")];
        Debug.Log("Equipo 1: " + PlayerPrefs.GetInt("team1"));
        UpdateTexts();
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;

        // Check if the time has ended
        if (remainingTime <= 0)
        {
            EndMatch();
        }

        UpdateTexts();
    }

    public void ScoreGoalTeamA()
    {
        teamAGoals++;
        UpdateTexts();
        Debug.Log("Goal for Team A!");
    }

    public void ScoreGoalTeamB()
    {
        teamBGoals++;
        UpdateTexts();
        Debug.Log("Goal for Team B!");
    }

    private void EndMatch()
    {
        Debug.Log("Match ended!");
        Debug.Log("Final result: Team A " + teamAGoals + " - Team B " + teamBGoals);
        // Perform actions you want at the end of the match, such as showing a victory message, restarting the match, etc.
    }

    private void UpdateTexts()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        string formattedTime = minutes.ToString("00") + ":" + seconds.ToString("00");

        teamAGoalsText.text = teamAGoals.ToString();
        teamBGoalsText.text = teamBGoals.ToString();
        remainingTimeText.text = formattedTime;
    }
}

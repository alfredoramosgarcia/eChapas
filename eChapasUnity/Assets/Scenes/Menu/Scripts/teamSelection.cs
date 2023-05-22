using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class teamSelection : MonoBehaviour
{
    public List<string> sTeams;
    public List<Sprite> teamShields;

    public Image teamShieldImage;
    public Text teamNameText;

    private int currentTeamIndex;

    public int player;

    private void Start(){
        ShowCurrentTeamInfo();
    }

    public void SelectNextTeam(){
        currentTeamIndex = (currentTeamIndex + 1) % sTeams.Count;
        ShowCurrentTeamInfo();
    }

    public void SelectPreviousTeam(){
        currentTeamIndex--;
        if (currentTeamIndex < 0)
            currentTeamIndex = sTeams.Count - 1;
        ShowCurrentTeamInfo();
    }

    private void ShowCurrentTeamInfo(){
        selectTeam();
        teamShieldImage.sprite = teamShields[currentTeamIndex];
        teamNameText.text = sTeams[currentTeamIndex];
    }

    private void selectTeam(){
        PlayerPrefs.SetInt("team" + player, currentTeamIndex);
    }
}
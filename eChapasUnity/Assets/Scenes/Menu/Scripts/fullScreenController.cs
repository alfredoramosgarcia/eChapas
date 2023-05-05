using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fullScreenController : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutionsDropdown;
    Resolution[] resolutions;

    void Start(){
        if(Screen.fullScreen)
            toggle.isOn = true;
        else
            toggle.isOn = false;
        checkResolution();
    }

    public void onFullScreen(bool fullScreen){
        Screen.fullScreen = fullScreen;
    }

    public void checkResolution(){
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int iActualResolution = 0;

        for(int i = 0 ; i < resolutions.Length ; i++){
            string sOption =  resolutions[i].width + " x " + resolutions[i].height;
            options.Add(sOption);
            
            if(Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                iActualResolution = i;
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = iActualResolution;
        resolutionsDropdown.RefreshShownValue();

        resolutionsDropdown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }

    public void changeResolution(int iResolution){
        PlayerPrefs.SetInt("numeroResolucion", resolutionsDropdown.value);
        Resolution resolution = resolutions[iResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

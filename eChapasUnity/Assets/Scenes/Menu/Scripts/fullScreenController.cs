using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fullScreenController : MonoBehaviour
{
    public Toggle toggle;

    void Start(){
        if(Screen.fullScreen)
            toggle.isOn = true;
        else
            toggle.isOn = false;
    }

    public void onFullScreen(bool fullScreen){
        Screen.fullScreen = fullScreen;
    }
}

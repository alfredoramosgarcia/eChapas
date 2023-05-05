using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlVolumen : MonoBehaviour
{   
    public Slider slider;
    public float sliderValue;
    public Image imageMute;

    void Start(){
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        checkMute();
    }

    public void changeSlider(float value){
        sliderValue = value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        checkMute();
    }

    public void checkMute(){
        if(sliderValue == 0)
            imageMute.enabled = true;
        else
            imageMute.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

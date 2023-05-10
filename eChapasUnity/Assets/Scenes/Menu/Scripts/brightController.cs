using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brightController : MonoBehaviour{
    public Slider slider;
    public float sliderValue;
    public Image brightPanel;

    void Start(){
        slider.value = PlayerPrefs.GetFloat("brillo", 0.0f);
        brightPanel.color = new Color(brightPanel.color.r, brightPanel.color.g, brightPanel.color.b, slider.value);
    }

    public void changeSlider(float value){
        sliderValue = value;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        brightPanel.color = new Color(brightPanel.color.r, brightPanel.color.g, brightPanel.color.b, slider.value);
    }
}

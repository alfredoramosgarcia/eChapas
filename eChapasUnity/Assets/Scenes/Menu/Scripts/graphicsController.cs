using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class graphicsController : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;

    void Start(){
        quality = PlayerPrefs.GetInt("numeroDeCalidad", 2);
        dropdown.value = quality;
        adjustQuaity();
    }

    public void adjustQuaity(){
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        quality = dropdown.value;
    }
}

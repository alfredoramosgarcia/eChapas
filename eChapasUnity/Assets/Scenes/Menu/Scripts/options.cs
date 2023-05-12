using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    public optionController optionsPanel;

    void Start(){
        optionsPanel = GameObject.FindGameObjectWithTag("Options").GetComponent<optionController>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
            showOptions();
    }

    public void showOptions(){
        optionsPanel.screenObject.SetActive(true);
    }
}

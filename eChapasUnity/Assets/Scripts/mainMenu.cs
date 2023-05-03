using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void scenceChanger(string sName){
        SceneManager.LoadScene(sName);    
    }

    public void quit(){
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    //public static sounds _instancia;
    public AudioSource sound;
    public AudioClip soundMenu;
    
    public void soundButton(){
        sound.clip = soundMenu;
        sound.enabled = false;
        sound.enabled = true;
    }
}

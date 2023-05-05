using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlMusica : MonoBehaviour
{
    public static controlMusica _instancia;
    public AudioSource sound;
    public AudioClip soundMenu;

    private void Awake(){
        if( controlMusica._instancia == null){
            controlMusica._instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void soundButton(){
        sound.clip = soundMenu;
        sound.enabled = false;
        sound.enabled = true;
    }
}

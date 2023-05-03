using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlMusica : MonoBehaviour
{
    public static controlMusica _instancia;

    private void Awake(){
        if( controlMusica._instancia == null){
            controlMusica._instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}

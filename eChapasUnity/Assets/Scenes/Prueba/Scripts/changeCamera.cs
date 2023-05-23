using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    public int playerNum;
    public Camera mainCamera;
    public GameObject playerCamera;
    
    private GameObject match;
    private MatchControl matchControl;
    private turnControl turnScript;
    
    private bool isInPlayerCamera = false; // Para controlar en que camara nos encontramos

    void Start(){
        match = GameObject.FindWithTag("Match");
        matchControl = match.GetComponent<MatchControl>();
        turnScript = FindObjectOfType<turnControl>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)) // esc
            if(isInPlayerCamera)
                ExitPlayerCamera();
    }

    // click en objeto
    private void OnMouseDown(){
        Debug.Log("Jugador clicado");
        if(!isInPlayerCamera && turnScript.GetCurrentTurn() == playerNum){
            MoveSecondaryCameraToTarget();
            matchControl.SetSelectedPlayer(gameObject);
        }
    }

    // Habilitar camara de jugador
    private void MoveSecondaryCameraToTarget(){ 
        Debug.Log("cambiando");
        // Cambiar camaras
        Camera.main.enabled = false;
        playerCamera.SetActive(true);
        isInPlayerCamera = true;
        //playerControl.target = gameObject.transform;
    }

    // Deshabilitar camara de jugador
    public void ExitPlayerCamera(){
        playerCamera.SetActive(false);
        mainCamera.enabled = true;
        isInPlayerCamera = false;
    }
}

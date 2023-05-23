using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    public int playerNum;
    public Camera mainCamera;
    public GameObject playerCamera;
    private GameObject player;

    private PlayerControl playerControl;
    private turnControl turnScript;

    private bool isInPlayerCamera = false; // Para controlar en que camara no encontramos

    void Start(){
        player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        turnScript = FindObjectOfType<turnControl>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)) // esc
            if(isInPlayerCamera)
                ExitPlayerCamera();
    }

    // click en objeto
    private void OnMouseDown(){
        if(!isInPlayerCamera && turnScript.GetCurrentTurn() == playerNum)
            MoveSecondaryCameraToTarget();
    }

    // Habilitar camara de jugador
    private void MoveSecondaryCameraToTarget(){ 
        Debug.Log("cambiando");
        // Cambiar camaras
        Camera.main.enabled = false;
        playerCamera.SetActive(true);
        isInPlayerCamera = true;
        playerControl.target = gameObject.transform;
    }

     // Deshabilitar camara de jugador
    public void ExitPlayerCamera(){
        playerCamera.SetActive(false);
        mainCamera.enabled = true;
        isInPlayerCamera = false;
    }
}

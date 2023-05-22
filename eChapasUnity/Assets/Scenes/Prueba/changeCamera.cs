using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject playerCamera;
    private GameObject player;
    //public CameraController playerScript;

    private bool isInPlayerCamera = false; // Para controlar en que camara no encontramos

    void Start(){
        player = GameObject.FindWithTag("Player");
        //playerScript = player.GetComponent<CameraController>(); 
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)) // esc
            if(isInPlayerCamera)
                ExitPlayerCamera();
    }

    // click en objeto
    private void OnMouseDown(){
        if(!isInPlayerCamera)
            MoveSecondaryCameraToTarget();
    }

    // Habilitar camara de jugador
    private void MoveSecondaryCameraToTarget(){ 
        Debug.Log("cambiando");
        // Cambiar camaras
        Camera.main.enabled = false;
        playerCamera.SetActive(true);
        isInPlayerCamera = true;
        //playerScript.setIsInPlayerCamera(true);
    }

     // Deshabilitar camara de jugador
    private void ExitPlayerCamera(){
        playerCamera.SetActive(false);
        mainCamera.enabled = true;
        isInPlayerCamera = false;
    }
}

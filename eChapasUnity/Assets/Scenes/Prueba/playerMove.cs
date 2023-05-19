using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capMove : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    private GameObject player;

    private bool isInPlayerCamera = false;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
            if (isInPlayerCamera)
                ExitPlayerCamera();
    }

    private void ExitPlayerCamera(){
        secondaryCamera.enabled = false;

        mainCamera.enabled = true;
        isInPlayerCamera = false;
    }

    private void OnMouseDown(){
        if (!isInPlayerCamera)
            MoveSecondaryCameraToTarget();
    }

    private void MoveSecondaryCameraToTarget(){
        Debug.Log("cambiando");
        // Cambiar camaras
        Camera.main.enabled = false;
        secondaryCamera.enabled = true;
        isInPlayerCamera = true;
        // Llama al método "MyFunction" en todos los componentes del objeto con el nombre del componente específico
        player.SendMessage("setIsInPlayerCamera", true);
    }
}

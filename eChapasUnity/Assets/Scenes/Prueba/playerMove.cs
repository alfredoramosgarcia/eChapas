using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capMove : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;

    private bool isInPlayerCamera = false;

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
        /*
        // Calcula la posición objetivo de la cámara secundaria
    Vector3 targetPosition = transform.position + (transform.right * 2) + (transform.up * 2 + (transform.forward * 1));

    // Calcula la rotación objetivo de la cámara secundaria
    Quaternion targetRotation = Quaternion.Euler(45f, transform.eulerAngles.y, 0f);

    // Mueve y rota la cámara secundaria hacia la posición y rotación objetivo
        secondaryCamera.transform.position = targetPosition;
        secondaryCamera.transform.rotation = targetRotation;

        // Apunta la cámara secundaria hacia este objeto
        secondaryCamera.transform.LookAt(transform);
        */
    }
}

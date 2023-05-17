using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform target;         // El objeto alrededor del cual la cámara orbitará
    public float orbitSpeed = 5f;    // Velocidad de rotación de la cámara
    public float distance = 1f;     // Distancia entre la cámara y el objetivo

    private Vector3 offset;          // Distancia inicial entre la cámara y el objetivo

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("El objetivo no está asignado en el componente ObjectOrbit.");
            return;
        }

        offset = transform.position - target.position;
    }

    void Update(){
        if (target == null)
            return;

        float horizontalInput = Input.GetAxis("Mouse X") * orbitSpeed;
        float verticalInput = Input.GetAxis("Mouse Y") * orbitSpeed;

        // Obtener el ángulo actual basado en la posición del mouse
        float rotationAngle = horizontalInput * Time.deltaTime;

        // Calcular la nueva posición de la cámara en función del ángulo de rotación
        Quaternion rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        //Vector3 newPosition = target.position + rotation * (offset.normalized * distance);
        Vector3 newPosition = rotation * (transform.position - target.position) + target.position;

        // Establecer la posición de la cámara y que mire al objetivo
        transform.position = newPosition;
        transform.LookAt(target);
    }
}


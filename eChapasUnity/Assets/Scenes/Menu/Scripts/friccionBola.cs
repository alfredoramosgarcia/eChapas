using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float frictionCoefficient = 0.15f; // Coeficiente de fricción
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = frictionCoefficient; // Establece el coeficiente de fricción como la resistencia al aire del Rigidbody
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) // Si colisiona con un objeto con la etiqueta "Plane"
        {
            // Calcula la fuerza de fricción
            Vector3 friction = -rb.velocity.normalized * frictionCoefficient * rb.mass * Physics.gravity.magnitude;
            rb.AddForce(friction); // Aplica la fuerza de fricción al Rigidbody
        }
    }
}


using UnityEngine;

public class Esfera : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Obtener la dirección de la colisión
            Vector3 direccion = collision.contacts[0].point - transform.position;

            // Mover la esfera fuera del objeto
            transform.position -= direccion.normalized * direccion.magnitude;

            Debug.Log("Me ha tocado la chapa");
        }
    }
}


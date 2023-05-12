using UnityEngine;

public class ReboteEsfera : MonoBehaviour
{
    public float fuerzaRebote = 10f; // La fuerza con la que la esfera rebota al chocar con el jugador
    private Vector3 direccionChapa;

    void Start()
    {
        direccionChapa = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 direccionRebote = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            GetComponent<Rigidbody>().velocity = direccionRebote.normalized * fuerzaRebote;

            // Calcular la dirección de la chapa como la dirección opuesta a la del rebote
            direccionChapa = -direccionRebote.normalized;
        }
    }

    void FixedUpdate()
    {
        // Mover la chapa en la dirección calculada en OnCollisionEnter
        GetComponent<Rigidbody>().velocity = direccionChapa * fuerzaRebote;

        // Mover la esfera en la misma dirección que la chapa
        if (GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            GetComponent<Rigidbody>().velocity = direccionChapa.normalized * fuerzaRebote;
        }
    }
}


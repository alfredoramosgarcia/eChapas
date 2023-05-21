using UnityEngine;

public class Porteria : MonoBehaviour
{
    public int contadorGoles = 0; // Contador de goles
    public Transform esfera; // Referencia al objeto que representa la esfera
    public Transform chapa; // Referencia al objeto que representa la chapa
    public Vector3 posicionInicialEsfera = new Vector3(0, 0, 0); // Posición inicial de la esfera
    public Vector3 posicionInicialChapa = new Vector3(2, -1, 0); // Posición inicial de la chapa

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Balon") // Comprobar si la esfera ha entrado en la portería
        {
            contadorGoles++; // Incrementar el contador de goles
            Debug.Log("Gol!"); // Mostrar un mensaje en la consola

            // Volver a colocar la esfera y la chapa en sus posiciones iniciales
            esfera.position = posicionInicialEsfera;
            chapa.position = posicionInicialChapa;

            // Detener la velocidad de la esfera y la chapa
            esfera.GetComponent<Rigidbody>().velocity = Vector3.zero;
            chapa.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}


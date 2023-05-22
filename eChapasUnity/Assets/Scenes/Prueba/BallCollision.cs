using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject golObjectLocal;
    public GameObject golObjectVisitante;
    public GameObject playerObject;
    private Vector3 initialPosition = new Vector3(0.78f, 0.572f, 0.45f);
    private Vector3 playerInitialPosition = new Vector3(-0.4929999f, 0.3f, 2.507f);
    private Rigidbody ballRigidbody;
    private int contadorLocal = 0;
    private int contadorVisitante = 0;

    private void Start()
    {
        // Obtener el componente Rigidbody del balón al inicio
        ballRigidbody = GetComponent<Rigidbody>();
        Debug.Log("Marcador: " + contadorLocal + "-" + contadorVisitante);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto colisionado es la portería local
        if (collision.gameObject == golObjectLocal)
        {
            // Volver a la posición inicial del balón
            transform.position = initialPosition;

            // Volver a la posición inicial del jugador
            playerObject.transform.position = playerInitialPosition;

            // Habilitar el componente Rigidbody del balón para que vuelva a moverse
            ballRigidbody.isKinematic = false;

            // Incrementar el contador de la portería local
            contadorLocal++;
            Debug.Log("Marcador: " + contadorLocal + "-" + contadorVisitante);
        }

        // Verificar si el objeto colisionado es la portería visitante
        if (collision.gameObject == golObjectVisitante)
        {
            // Volver a la posición inicial del balón
            transform.position = initialPosition;

            // Volver a la posición inicial del jugador
            playerObject.transform.position = playerInitialPosition;

            // Habilitar el componente Rigidbody del balón para que vuelva a moverse
            ballRigidbody.isKinematic = false;

            // Incrementar el contador de la portería visitante
            contadorVisitante++;
            Debug.Log("Marcador: " + contadorLocal + "-" + contadorVisitante);
        }

         
    }
}


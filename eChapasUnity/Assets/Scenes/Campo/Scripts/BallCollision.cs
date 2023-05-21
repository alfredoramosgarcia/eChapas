using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject golObject;
    public GameObject playerObject;
    private Vector3 initialPosition = new Vector3(0.78f, 0.572f, 0.45f);
    private Vector3 playerInitialPosition = new Vector3(-0.4929999f, 0.3f, 2.507f);
    private Rigidbody ballRigidbody;

    private void Start()
    {
        // Obtener el componente Rigidbody del balón al inicio
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto colisionado es el objeto objetivo referenciado
        if (collision.gameObject == golObject)
        {
            // Volver a la posición inicial del balón
            transform.position = initialPosition;

            // Volver a la posición inicial del jugador
            playerObject.transform.position = playerInitialPosition;

            // Habilitar el componente Rigidbody del balón para que vuelva a moverse
            ballRigidbody.isKinematic = false;
        }
    }
}


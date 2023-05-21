using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private CharacterController controller;
    private float verticalSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obtener la entrada del teclado para el movimiento
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        movementDirection.Normalize();

        // Aplicar la velocidad de movimiento
        Vector3 movement = movementDirection * movementSpeed;
        movement += Vector3.up * verticalSpeed;

        // Aplicar la gravedad
        if (!controller.isGrounded)
        {
            verticalSpeed += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalSpeed = 0f;
        }

        // Mover el personaje
        controller.Move(movement * Time.deltaTime);
    }
}


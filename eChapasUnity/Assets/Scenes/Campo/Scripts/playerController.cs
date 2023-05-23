using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string playerTag = "Player";
    private bool isSelected = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetRigidbodyIsKinematic(true); // Hacer todos los jugadores estáticos al inicio
    }

    private void Update()
    {
        if (isSelected)
        {
            // Control de movimiento para el jugador seleccionado
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * 5.0f;
        }
        else
        {
            // Detener a todos los jugadores no seleccionados
            SetRigidbodyIsKinematic(true);
        }

        // Deseleccionar jugador al hacer clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            isSelected = false;
            SetRigidbodyIsKinematic(true);
        }
    }

    private void OnMouseDown()
    {
        if (!isSelected && CompareTag(playerTag))
        {
            // Seleccionar jugador al hacer clic izquierdo
            isSelected = true;
            SetRigidbodyIsKinematic(false);
        }
    }

    private void SetRigidbodyIsKinematic(bool isKinematic)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        
        foreach (GameObject player in players)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            playerRigidbody.isKinematic = isKinematic;
        }
    }
}


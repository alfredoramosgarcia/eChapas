using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    public GameObject chapa; // La chapa que se moverá
    public float fuerza = 10.0f; // La fuerza con la que se lanzará la chapa

    private Rigidbody chapaRigidbody; // Referencia al RigidBody de la chapa

    private void Start()
    {
        chapaRigidbody = chapa.GetComponent<Rigidbody>(); // Obtener la referencia del RigidBody de la chapa
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Si se presiona el botón izquierdo del ratón (0 es el código para el botón izquierdo)
        {
<<<<<<< HEAD:eChapasUnity/Assets/MovimientoPlayer.cs
            Vector3 direccion = (Camera.main.transform.position - transform.position).normalized;
=======
            Vector3 direccion = transform.forward; // Obtener la dirección en la que está apuntando el FPSController
>>>>>>> parent of b1cc2bb (he):eChapasUnity/Assets/Scenes/Campo/Scripts/MoverChapa.cs

            chapaRigidbody.AddForce(direccion * fuerza, ForceMode.Impulse); // Aplicar una fuerza a la chapa en la dirección del FPSController
        }
    }
}


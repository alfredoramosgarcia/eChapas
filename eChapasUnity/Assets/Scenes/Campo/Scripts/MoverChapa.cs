using UnityEngine;

public class MoverChapa : MonoBehaviour
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
           Vector3 direccion = -(Camera.main.transform.position - transform.position).normalized;



            chapaRigidbody.AddForce(direccion * fuerza, ForceMode.Impulse); // Aplicar una fuerza a la chapa en la dirección del FPSController
        }
    }
}


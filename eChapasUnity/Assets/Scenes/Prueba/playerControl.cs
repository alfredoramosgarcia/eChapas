using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform target; // El objeto alrededor del cual la cámara girará
    public float rotationSpeed = 5f; // Velocidad de rotación de la cámara
    public float launchForce = 10f; // Fuerza de lanzamiento del objeto

    private bool isInPlayerCamera;

    private Vector3 offset; // Distancia entre la cámara y el objeto

    private void Start()
    {
        // Calcula la distancia inicial entre la cámara y el objeto
        offset = new Vector3(0f, 2f, -5f); // Ajusta los valores según tu preferencia
    }

    private void Update()
    {
        // Calcula el ángulo de rotación basado en el movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X");
        float rotationAngle = mouseX * rotationSpeed;

        // Rota la cámara alrededor del objeto
        Quaternion rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        offset = rotation * offset;

        // Actualiza la posición de la cámara basada en el objeto y la distancia offset
        transform.position = target.position + offset;

        // Hace que la cámara mire hacia el objeto
        transform.LookAt(target);

        //Debug.Log("Antes del click: " + isInPlayerCamera);
        // Lanza el objeto en la dirección del eje X cuando se hace clic con el ratón
        if (Input.GetMouseButtonDown(0) && isInPlayerCamera)
        {
            Debug.Log("Tiro");
            Vector3 launchDirection = transform.forward; // Obtiene la dirección del eje X de la cámara
            target.GetComponent<Rigidbody>().AddForce(launchDirection * launchForce, ForceMode.Impulse);
        }
    }

    private void OnEnable(){
        Debug.Log("Camara habilitada " + isInPlayerCamera);
        isInPlayerCamera = true;
    }

    private void OnDisable(){ isInPlayerCamera = false; }
}

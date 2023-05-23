using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform target; // El objeto alrededor del cual la cámara girará
    public float rotationSpeed = 5f; // Velocidad de rotación de la cámara

    private Vector3 offset; // Distancia entre la cámara y el objeto
    private bool isInPlayerCamera;

    public float minForce = 10f; // Fuerza mínima del disparo
    public float maxForce = 100f; // Fuerza máxima del disparo
    public float maxHoldTime = 2f; // Tiempo máximo de presión

    private bool isCharging = false; // Indica si se está cargando el disparo
    private float holdTime = 0f; // Tiempo de presión

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

        if(Input.GetKeyDown(KeyCode.Space)) { StartCharging(); }

        if(Input.GetKey(KeyCode.Space)) { ContinueCharging(); }

        if (Input.GetKeyUp(KeyCode.Space)) { Shoot(); }
    }

    private void OnEnable(){ 
        isInPlayerCamera = true;
        FindObjectOfType<changeCamera>().onClicked.AddListener(SetTarget);

    }

    private void OnDisable(){
        isInPlayerCamera = false;
        FindObjectOfType<changeCamera>().onClicked.RemoveListener(SetTarget);
    }

    public void SetTarget(GameObject clickedObject){
        target = clickedObject.transform;
    }

    private void StartCharging()
    {
        isCharging = true;
        holdTime = 0f;
    }

    private void ContinueCharging(){
        if (!isCharging)
        {
            return;
        }

        holdTime += Time.deltaTime;
        holdTime = Mathf.Clamp(holdTime, 0f, maxHoldTime); // Limitar el tiempo máximo de presión

        // Calcular la fuerza del disparo según el tiempo de presión
        float force = Mathf.Lerp(minForce, maxForce, holdTime / maxHoldTime);
        Debug.Log("Fuerza del disparo: " + force);
    }

    private void Shoot()
    {
        if (!isCharging)
        {
            return;
        }

        // Realizar la acción de disparo aquí, por ejemplo, aplicar una fuerza al Rigidbody del proyectil
        float force = Mathf.Lerp(minForce, maxForce, holdTime / maxHoldTime);
        Debug.Log("Tiro");
        Vector3 launchDirection = transform.forward; // Obtiene la dirección del eje X de la cámara
        target.GetComponent<Rigidbody>().AddForce(launchDirection * force, ForceMode.Impulse);

        // Reiniciar las variables de carga
        isCharging = false;
        holdTime = 0f;
    }
}

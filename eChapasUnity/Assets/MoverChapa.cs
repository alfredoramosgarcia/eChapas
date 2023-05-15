using UnityEngine;

public class MoverChapa : MonoBehaviour
{
    public GameObject balon; // El balón hacia el que se moverá
    public float fuerza = 10.0f; // La fuerza con la que se lanzará la chapa

    private Rigidbody chapaRigidbody; // Referencia al RigidBody de la chapa

    private void Start()
    {
        chapaRigidbody = GetComponent<Rigidbody>(); // Obtener la referencia del RigidBody de la chapa
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Si se presiona el botón izquierdo del ratón (0 es el código para el botón izquierdo)
        {
            GameObject objetoMasCercano = BuscarObjetoMasCercanoConTag("Balon");
            if (objetoMasCercano != null)
            {
                Vector3 direccion = (objetoMasCercano.transform.position - transform.position).normalized;

                chapaRigidbody.AddForce(direccion * fuerza, ForceMode.Impulse); // Aplicar una fuerza a la chapa en la dirección del balón
            }
        }
    }

    private GameObject BuscarObjetoMasCercanoConTag(string tag)
    {
        GameObject[] objetosConTag = GameObject.FindGameObjectsWithTag(tag);
        GameObject objetoMasCercano = null;
        float distanciaMasCorta = Mathf.Infinity;
        Vector3 posicionActual = transform.position;
        foreach (GameObject objeto in objetosConTag)
        {
            Vector3 direccion = objeto.transform.position - posicionActual;
            float distancia = direccion.sqrMagnitude;
            if (distancia < distanciaMasCorta)
            {
                distanciaMasCorta = distancia;
                objetoMasCercano = objeto;
            }
        }
        return objetoMasCercano;
    }
}


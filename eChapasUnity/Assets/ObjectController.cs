using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public Transform fps;
    public Transform arrow;

    private void Update()
    {
        // Obtiene la dirección del FPS al objeto
        Vector3 direction = (fps.position - transform.position).normalized;

        // Calcula el ángulo de rotación
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Establece la rotación de la flecha
        arrow.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

        // Mueve la flecha hacia delante en esa dirección
        arrow.Translate(Vector3.up * 0.2f);
    }
}


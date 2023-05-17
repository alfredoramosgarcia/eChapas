using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capCollision : MonoBehaviour
{
   void OnTriggerEnter(Collider other){
        // Verifica si el objeto colisionado tiene una etiqueta específica
        if (other.gameObject.CompareTag("Balon"))
        {
            // Activa el trigger de la animación
            GetComponent<Animator>().SetTrigger("shoot");
        }
    }




}

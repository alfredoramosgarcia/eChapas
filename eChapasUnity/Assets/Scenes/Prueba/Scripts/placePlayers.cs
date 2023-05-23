using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlayers : MonoBehaviour
{   /*
    public GameObject prefabToSpawn; // Prefab que se va a instanciar
    public Transform[] spawnPositions; // Lista de posiciones donde se instanciarán los prefabs

    private void Start()
    {
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            // Instanciar el prefab en la posición actual de la lista
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPositions[i].position, Quaternion.Euler(-90f, 0f, 0f));
        }
    }
*/
    public GameObject objectPrefab; // Prefab del objeto a generar
    public int numberOfObjects = 5; // Número de objetos a generar
    public Vector3[] initialPositions; // Vector público de posiciones iniciales

    private GameObject[] generatedObjects; // Array para almacenar los objetos generados

    private void Start()
    {
        generatedObjects = new GameObject[numberOfObjects]; // Inicializar el array de objetos generados

        // Generar los objetos
        for (int i = 0; i < numberOfObjects; i++)
        {
            generatedObjects[i] = Instantiate(objectPrefab, initialPositions[i], Quaternion.identity, transform); // Generar el objeto con la posición inicial específica
            generatedObjects[i].transform.rotation = Quaternion.Euler(-90f, 0f, 0f); // Rotar el objeto en el eje X a -90 grados
        }
    }

    public void MoveObjectsToInitialPositions()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            generatedObjects[i].transform.position = initialPositions[i]; // Mover cada objeto a su posición inicial
        }
    }
}

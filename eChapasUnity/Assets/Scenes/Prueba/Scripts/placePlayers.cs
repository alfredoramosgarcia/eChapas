using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
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
}

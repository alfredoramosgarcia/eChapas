using UnityEngine;

public class colocarPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform fieldCenter;
    public float spacing = 2f;

    void Start()
    {
        ReplicatePlayers();
    }

    void ReplicatePlayers()
    {
        // Crear jugador central
        GameObject centralPlayer = Instantiate(playerPrefab, fieldCenter.position, Quaternion.identity);

        // Crear jugadores en formación 1-3-2-1
        CreatePlayerReplica(centralPlayer.transform, Vector3.forward * spacing); // Forward
        CreatePlayerReplica(centralPlayer.transform, Vector3.left * spacing); // Left
        CreatePlayerReplica(centralPlayer.transform, Vector3.right * spacing); // Right

        CreatePlayerReplica(centralPlayer.transform, Vector3.forward * spacing * 2); // Forward
        CreatePlayerReplica(centralPlayer.transform, (Vector3.left + Vector3.forward) * spacing * 2); // Left-Forward
        CreatePlayerReplica(centralPlayer.transform, (Vector3.right + Vector3.forward) * spacing * 2); // Right-Forward

        CreatePlayerReplica(centralPlayer.transform, Vector3.forward * spacing * 3); // Forward
    }

    void CreatePlayerReplica(Transform parent, Vector3 offset)
    {
        GameObject replica = Instantiate(playerPrefab, parent.position + offset, Quaternion.identity);
        replica.transform.SetParent(parent);
    }
}


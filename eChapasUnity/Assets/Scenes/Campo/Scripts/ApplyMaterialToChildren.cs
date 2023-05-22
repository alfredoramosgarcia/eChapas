using UnityEngine;

public class ApplyMaterialToChildren : MonoBehaviour
{
    public Material sharedMaterial;

    private void Start()
    {
        ApplyMaterialRecursive(transform);
    }

    private void ApplyMaterialRecursive(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Renderer renderer = child.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.material = sharedMaterial;
            }

            if (child.childCount > 0)
            {
                ApplyMaterialRecursive(child);
            }
        }
    }
}


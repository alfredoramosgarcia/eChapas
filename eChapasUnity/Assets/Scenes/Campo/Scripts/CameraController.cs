using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;
    private Transform playerTransform;
    private Transform initialCameraTransform;

    private bool isSelected = false;
    private bool hasMoved = false;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        mainCamera = Camera.main;
        initialCameraTransform = mainCamera.transform;
    }

    private void LateUpdate()
    {
        if (isSelected)
        {
            if (playerTransform != null)
            {
                Vector3 desiredPosition = playerTransform.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;

                transform.LookAt(playerTransform);
            }
        }
        else if (hasMoved)
        {
            Vector3 desiredPosition = initialCameraTransform.position;
            Quaternion desiredRotation = initialCameraTransform.rotation;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        }
    }

    public void SetSelectedPlayer(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
        isSelected = true;
        hasMoved = false;
    }

    public void PlayerHasMoved()
    {
        hasMoved = true;
        isSelected = false;
    }
}


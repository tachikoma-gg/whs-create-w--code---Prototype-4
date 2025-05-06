using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 30f;
    private Vector3 cameraRotation;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        cameraRotation.y += mouseX * mouseSensitivity;
        transform.rotation = Quaternion.Euler(cameraRotation);
    }
}

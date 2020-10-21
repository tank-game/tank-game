using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform anchor;
    public float sensitivity;

    public float maxElevation;
    public float maxDepression;

    public Turret turret;

    private float yaw, pitch;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -maxElevation, maxDepression);

        anchor.localRotation = Quaternion.Euler(pitch, yaw, 0f);
        turret.RotateTo(yaw, pitch);
    }
}

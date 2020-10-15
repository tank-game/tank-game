using UnityEngine;

public class ThirdPersonCameraControllerNew : MonoBehaviour
{
    public Transform target, player;
    public float rotationSpeed;

    public bool locked;
    public bool lockCursor;

    private float mouseX, mouseY, cameraY, cameraZ;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        /* Movement */

        if (locked)
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Mathf.Clamp(Input.GetAxis("Mouse Y") * rotationSpeed, -35, 60);

            transform.LookAt(target);

            target.localRotation = Quaternion.Euler(mouseY, 0, 0);
            player.localRotation = Quaternion.Euler(0, mouseX, 0);

        }

        /* Zooming */

        // if (Input.GetKeyDown("-"))
        // {
        //     transform.position = (transform.position + new Vector3(0, 0, -1));
        // }

        // if (Input.GetKeyDown("="))
        // {
        //     transform.position = (transform.position + new Vector3(0, 0, 1));
        // }

        // if (Input.GetKeyDown("["))
        // {
        //     transform.position = (transform.position + new Vector3(0, -1, 0));
        // }

        // if (Input.GetKeyDown("]"))
        // {
        //     transform.position = (transform.position + new Vector3(0, 1, 0));
        // }

        /* Locking */

        // if (Input.GetMouseButtonDown(1))
        // {
        //     camera1.gameObject.SetActive(false);
        //     camera2.gameObject.SetActive(true);
        //     cameraLock = false;
        // }
        // else
        // {
        //     camera1.gameObject.SetActive(true);
        //     camera2.gameObject.SetActive(false);
        //     cameraLock = true;
        // }
    }
}
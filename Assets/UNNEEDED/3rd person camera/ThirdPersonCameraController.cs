using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform Target, Player, Camera;
    float mouseX, mouseY, cameraY, cameraZ;
    bool cameraLock;
    public Camera camera1;
    public Camera camera2;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }

    private void Update()
    {
        CamControl();

        CamZoom();

        CamLock();
    }

    void CamControl()
    {
        if (cameraLock == true)
        {


            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(Target);

            Target.localRotation = Quaternion.Euler(mouseY, 0, 0);
            Player.localRotation = Quaternion.Euler(0, mouseX, 0);

        }
    }

    void CamZoom()
    {
        if (Input.GetKeyDown("-"))
        {
            transform.position = (transform.position + new Vector3(0, 0, -1));
        }

        if (Input.GetKeyDown("="))
        {
            transform.position = (transform.position + new Vector3(0, 0, 1));
        }

        if (Input.GetKeyDown("["))
        {
            transform.position = (transform.position + new Vector3(0, -1, 0));
        }

        if (Input.GetKeyDown("]"))
        {
            transform.position = (transform.position + new Vector3(0, 1, 0));
        }

    }

    void CamLock()
    {
        {
            if (Input.GetMouseButtonDown(1))
            {
                camera1.gameObject.SetActive(false);
                camera2.gameObject.SetActive(true);
                cameraLock = false;
            }
            else
            {
                camera1.gameObject.SetActive(true);
                camera2.gameObject.SetActive(false);
                cameraLock = true;
            }
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform Target, Player, Camera;
    float mouseX, mouseY, cameraY, cameraZ;

   
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CamControl();

        CamZoom();

        //Camera.localPosition = (0, cameraY, cameraZ);
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.localRotation = Quaternion.Euler(mouseY, 0, 0);
        Player.localRotation = Quaternion.Euler(0, mouseX, 0);
    }

    void CamZoom()
    {
        if (Input.GetKeyDown ("-"))
        {

        }
    }

}

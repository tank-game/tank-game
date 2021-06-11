using UnityEngine;

public class followcube : MonoBehaviour
{
    public Transform anchor;
    public float sensitivity;

    public GameObject[] anchorSelect;

    //public Turret turret;

    private float yaw, pitch;

    public GameObject radialmenu;
    public MenuScript MenuScript;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        anchor.localRotation = Quaternion.Euler(pitch, yaw, 0f);
         //turret.RotateTo(yaw, pitch);

      //if (selection = 1)
       // {
          // gameObject.transform.parent = anchorSelect[selection].transform;
       // }

       
    }
}

using UnityEngine;

public class TankController : MonoBehaviour
{
    public Tank tank;

    private float movementInput, rotationInput;

    void Update()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.E))
        {
            tank.ToggleGear();
        }
    }

    void FixedUpdate()
    {
        tank.Move(movementInput, rotationInput);
    }
}

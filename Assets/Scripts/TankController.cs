using UnityEngine;

public class TankController : MonoBehaviour
{
    public Tank tank;

    private float movementInput, rotationInput;

    void Update()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            tank.gear = Tank.Gear.Drive;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            tank.gear = Tank.Gear.Reverse;
        }
    }

    void FixedUpdate()
    {
        tank.Move(movementInput, rotationInput);
    }
}

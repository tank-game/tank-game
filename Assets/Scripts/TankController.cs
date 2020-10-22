using UnityEngine;

public class TankController : MonoBehaviour
{
    public Tank tank;

    private float movementInput, rotationInput;

    void Update()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        tank.Move(movementInput, rotationInput);
    }
}

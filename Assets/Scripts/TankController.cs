using UnityEngine;
using TMPro;

public class TankController : MonoBehaviour
{
    public Tank tank;

    [Header("Graphics")]
    public TextMeshProUGUI gearIndicator;

    private float movementInput, rotationInput;

    void Update()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.E))
        {
            tank.ToggleGear();
        }

        gearIndicator.text = tank.ActiveGear() == Gear.Drive ? "Drive" : "Reverse";

        if (Input.GetMouseButton(0))
        {
            GetComponent<Target>().Hit(50 * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        tank.Move(movementInput, rotationInput);
    }
}

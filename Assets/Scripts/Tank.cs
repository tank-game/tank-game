using UnityEngine;

public enum Gear
{
    Drive,
    Reverse
}

[RequireComponent(typeof(Rigidbody))]
public class Tank : MonoBehaviour
{
    public Transform centreOfMass;

    private Rigidbody rb;
    private Wheel[] wheels;

    [Header("Gearbox")]
    public Gear[] gears;

    private int activeGear;

    [Header("Engine")]
    [Range(10f, 100f)] public float accelerationForce;
    [Range(10f, 100f)] public float brakeForce;

    [Range(5f, 30f)] public float topSpeed; // In metres/second
    [Range(5f, 30f)] public float turnRate; // In degrees/second

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (centreOfMass != null)
        {
            rb.centerOfMass = centreOfMass.localPosition;
        }

        wheels = GetComponentsInChildren<Wheel>();

        activeGear = 0;
    }

    public void Move(float movementInput, float rotationInput)
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            Wheel currentWheel = wheels[i];
            WheelCollider currentWheelCollider = currentWheel.wheelCollider;

            if (movementInput >= 0f)
            {
                currentWheelCollider.brakeTorque = 0f;

                int direction = ActiveGear() == Gear.Drive ? 1 : -1;
                currentWheelCollider.motorTorque = direction * movementInput * accelerationForce;

                // Directly limits the tank's velocity
                if (rb.velocity.magnitude >= topSpeed)
                {
                    rb.velocity = rb.velocity.normalized * topSpeed;
                }
            }
            else
            {
                currentWheelCollider.motorTorque = 0f;
                currentWheelCollider.brakeTorque = Mathf.Abs(movementInput) * brakeForce;
            }
        }

        Quaternion deltaRotation = Quaternion.AngleAxis(
            rotationInput * turnRate * Time.deltaTime,
            transform.up
        );
        rb.MoveRotation(transform.rotation * deltaRotation);
    }

    public void ToggleGear()
    {
        activeGear += 1;
        if (activeGear == gears.Length)
        {
            activeGear = 0;
        }
    }

    private Gear ActiveGear()
    {
        return gears[activeGear];
    }
}

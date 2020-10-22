using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tank : MonoBehaviour
{
    public Transform centreOfMass;

    [Range(5000f, 15000f)] public float accelerationForce;
    public bool automaticBraking;

    [Range(5f, 15f)] public float topSpeed; // In metres/second
    [Range(5f, 40f)] public float turnRate; // In degrees/second

    private Rigidbody rb;
    private Wheel[] wheels;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (centreOfMass) { rb.centerOfMass = centreOfMass.localPosition; }

        wheels = GetComponentsInChildren<Wheel>();
    }

    public void Move(float movementInput, float rotationInput)
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            WheelCollider currentWheelCollider = wheels[i].wheelCollider;

            if (movementInput == 0f)
            {
                currentWheelCollider.brakeTorque = automaticBraking ? 1f : 0f;
            }
            else
            {
                currentWheelCollider.brakeTorque = 0f;
                currentWheelCollider.motorTorque = movementInput * accelerationForce;
            }
        }

        // Directly limits the tank's velocity
        if (rb.velocity.magnitude >= topSpeed)
        {
            rb.velocity = rb.velocity.normalized * topSpeed;
        }

        Quaternion deltaRotation = Quaternion.AngleAxis(
            rotationInput * turnRate * Time.deltaTime,
            transform.up
        );
        rb.MoveRotation(transform.rotation * deltaRotation);
    }
}

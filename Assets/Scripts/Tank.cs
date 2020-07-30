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

    [Header("Gearbox")]
    public Gear[] gears;

    private int activeGear;

    [Header("Engine")]
    [Range(10f, 100f)] public float accelerationForce;
    [Range(10f, 100f)] public float brakeForce;

    [Range(5f, 30f)] public float topSpeed; // In metres/second
    [Range(5f, 30f)] public float turnRate; // In degrees/second

    [Header("Tracks")]
    public GameObject wheelModelPrefab;
    public bool automaticScaling;

    private WheelCollider[] wheelColliders;
    private GameObject[] wheelModels;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (centreOfMass != null)
        {
            rb.centerOfMass = centreOfMass.localPosition;
        }

        activeGear = 0;

        wheelColliders = GetComponentsInChildren<WheelCollider>();
        wheelModels = new GameObject[wheelColliders.Length];

        for (int i = 0; i < wheelColliders.Length; i++)
        {
            WheelCollider currentWheelCollider = wheelColliders[i];

            GameObject wheelModel = Instantiate(wheelModelPrefab, currentWheelCollider.transform, false);
            if (automaticScaling)
            {
                wheelModel.transform.localScale = Vector3.one * wheelColliders[i].radius * 2f;

            }
            wheelModels[i] = wheelModel;
        }
    }

    public void Move(float movementInput, float rotationInput)
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            WheelCollider currentWheelCollider = wheelColliders[i];
            GameObject currentWheelModel = wheelModels[i];

            if (movementInput >= 0f)
            {
                currentWheelCollider.brakeTorque = 0f;

                int direction = gears[activeGear] == Gear.Drive ? 1 : -1;
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

            Vector3 position;
            Quaternion rotation;
            currentWheelCollider.GetWorldPose(out position, out rotation);

            currentWheelModel.transform.position = position;
            currentWheelModel.transform.rotation = rotation;
        }

        Quaternion deltaRotation = Quaternion.AngleAxis(
            rotationInput * turnRate * Time.deltaTime,
            transform.up
        );
        rb.MoveRotation(transform.rotation * deltaRotation);
    }

    public void ToggleGear()
    {
        if (activeGear == gears.Length - 1)
        {
            activeGear = 0;
        }
        else
        {
            activeGear += 1;
        }
    }
}

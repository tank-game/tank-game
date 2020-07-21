using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tank : MonoBehaviour
{
    public enum Gear
    {
        Drive,
        Reverse
    }

    [Header("Engine")]
    [Range(50f, 250f)] public float accelerationForce;
    public float brakeForce;
    [Range(5f, 25f)] public float topSpeed; // In metres/second

    [Range(5f, 25f)] public float turnRate; // In degrees/second

    public Transform wheelModelPrefab;

    private Rigidbody rb;

    private WheelCollider[] wheelColliders;
    private Transform[] wheelModels;

    public Gear gear;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        wheelColliders = GetComponentsInChildren<WheelCollider>();
        wheelModels = new Transform[wheelColliders.Length];
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            Transform wheelModel = Instantiate(wheelModelPrefab, wheelColliders[i].transform, false);
            wheelModel.localScale = Vector3.one * wheelColliders[i].radius * 2f;
            wheelModels[i] = wheelModel;
        }
    }

    public void Move(float movementInput, float rotationInput)
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            WheelCollider wheel = wheelColliders[i];

            if (movementInput >= 0)
            {
                wheel.brakeTorque = 0;

                float direction = gear == Gear.Drive ? 1 : -1;
                wheel.motorTorque = direction * movementInput * accelerationForce;
            }
            else
            {
                wheel.motorTorque = 0;
                wheel.brakeTorque = -1 * movementInput * brakeForce;
            }

            // wheel.motorTorque = rb.velocity.magnitude <= topSpeed ? movementInput * accelerationForce : 0f;

            Vector3 position;
            Quaternion rotation;
            wheel.GetWorldPose(out position, out rotation);
            wheelModels[i].position = position;
            wheelModels[i].rotation = rotation;
        }

        Quaternion deltaRotation = Quaternion.AngleAxis(
            rotationInput * turnRate * Time.deltaTime,
            transform.up
        );
        rb.MoveRotation(transform.rotation * deltaRotation);
    }
}

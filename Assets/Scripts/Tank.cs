using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tank : MonoBehaviour
{
    [Header("Engine")]
    [Range(50f, 250f)] public float accelerationForce;
    [Range(5f, 25f)] public float topSpeed; // In metres/second
    [Range(5f, 25f)] public float rotationRate; // In degrees/second

    public Transform wheelModelPrefab;

    private Rigidbody rb;

    private WheelCollider[] wheelColliders;
    private Transform[] wheelModels;

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
            wheel.motorTorque = rb.velocity.magnitude <= topSpeed ? movementInput * accelerationForce : 0f;

            Vector3 position;
            Quaternion rotation;
            wheel.GetWorldPose(out position, out rotation);
            wheelModels[i].position = position;
            wheelModels[i].rotation = rotation;
        }

        Quaternion deltaRotation = Quaternion.AngleAxis(
            rotationInput * rotationRate * Time.deltaTime,
            transform.up
        );
        rb.MoveRotation(transform.rotation * deltaRotation);
    }
}

using UnityEngine;

public class Wheel : MonoBehaviour
{
    [HideInInspector] public WheelCollider wheelCollider;

    public Transform model;
    public bool scaleModel;

    public Transform bone;

    void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();

        if (scaleModel)
        {
            float wheelDiameter = wheelCollider.radius * 2f;
            model.localScale = Vector3.one * wheelDiameter;
        }
    }

    void Update()
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        model.position = position;
        bone.position = position;
    }
}

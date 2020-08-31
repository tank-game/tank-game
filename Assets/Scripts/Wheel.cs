using UnityEngine;

public class Wheel : MonoBehaviour
{
    [HideInInspector] public WheelCollider wheelCollider;

    public Transform model;
    public bool scaleModel;
    public bool rotateModel;

    public Transform bone;

    void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();

        if (scaleModel)
        {
            float wheelDiameter = wheelCollider.radius * 2f * 0.9f;
            model.localScale = Vector3.one * wheelDiameter;
        }
    }

    void Update()
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        model.position = position;
        if (rotateModel) { model.rotation = rotation; }

        bone.position = position;
    }
}

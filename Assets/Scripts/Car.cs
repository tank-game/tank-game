using UnityEngine;

public class Car : MonoBehaviour
{
    public float motorTorque;
    public float turnAggression;

    public WheelCollider[] frontWheels;
    public WheelCollider[] rearWheels;

    void Update()
    {
        foreach (WheelCollider wheel in frontWheels)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * motorTorque;
            wheel.steerAngle = Input.GetAxis("Horizontal") * turnAggression;
        }

        foreach (WheelCollider wheel in rearWheels)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        }
    }
}

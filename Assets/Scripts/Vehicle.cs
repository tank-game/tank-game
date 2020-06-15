using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float motorForce;
    public float steerForce;
    public float brakeForce;

    public WheelCollider frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel;

    void Update()
    {
        float movement = Input.GetAxis("Vertical") * motorForce;
        float steering = Input.GetAxis("Horizontal") * steerForce;
        float braking = Input.GetKey(KeyCode.Space) ? brakeForce : 0;

        rearLeftWheel.motorTorque = movement;
        rearRightWheel.motorTorque = movement;

        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;

        rearLeftWheel.brakeTorque = braking;
        rearRightWheel.brakeTorque = braking;
    }
}

using UnityEngine;

public class Tank : MonoBehaviour
{
    [Header("Movement")]
    public float motorTorque;
    public float turnAggression;

    public WheelCollider[] leftWheels, rightWheels;

    void Update()
    {
        foreach (WheelCollider wheel in leftWheels)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        }

        foreach (WheelCollider wheel in rightWheels)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        }
    }
}

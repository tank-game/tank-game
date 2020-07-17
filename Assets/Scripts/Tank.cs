﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tank : MonoBehaviour
{
    [Header("Engine")]
    [Range(50f, 250f)] public float accelerationForce;
    [Range(5f, 25f)] public float topSpeed; // In metres/second
    [Range(5f, 25f)] public float rotationRate; // In degrees/second

    private Rigidbody rb;
    private WheelCollider[] wheels;

    private float movementInput, rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wheels = GetComponentsInChildren<WheelCollider>();
    }

    void Update()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = rb.velocity.magnitude <= topSpeed ? movementInput * accelerationForce : 0f;
        }

        Quaternion deltaRotation = Quaternion.AngleAxis(
            rotationInput * rotationRate * Time.deltaTime,
            transform.up
        );
        rb.MoveRotation(transform.rotation * deltaRotation);
    }
}

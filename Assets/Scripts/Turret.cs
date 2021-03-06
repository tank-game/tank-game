﻿using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform mantlet;

    // [Range(0f, 0.099f)] public float smoothness;
    public float rotationSpeed;

    public float maxElevation;
    public float maxDepression;

    public void RotateTo(float yaw, float pitch)
    {
        pitch = Mathf.Clamp(pitch, -maxElevation, maxDepression);

        // float realSmoothness = 0.1f - smoothness;

        Vector3 targetRotation = transform.localRotation.eulerAngles;
        targetRotation.y = yaw;

        // transform.localRotation = Quaternion.Lerp(
        //     transform.localRotation,
        //     Quaternion.Euler(targetRotation),
        //     realSmoothness
        // );

        transform.localRotation = Quaternion.RotateTowards(
            transform.localRotation,
            Quaternion.Euler(targetRotation),
            Time.deltaTime * rotationSpeed
        );

        Vector3 targetMantletRotation = mantlet.localRotation.eulerAngles;
        targetMantletRotation.x = pitch;

        // mantlet.localRotation = Quaternion.Lerp(
        //     mantlet.localRotation,
        //     Quaternion.Euler(targetMantletRotation),
        //     realSmoothness
        // );

        mantlet.localRotation = Quaternion.RotateTowards(
            mantlet.localRotation,
            Quaternion.Euler(targetMantletRotation),
            Time.deltaTime * rotationSpeed
        );
    }

    // public void AimAt(Vector3 point)
    // {
    //     Quaternion lookRotation = Quaternion.LookRotation(point - transform.position, Vector3.up);

    //     transform.rotation = Quaternion.Lerp(
    //         transform.rotation,
    //         Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f),
    //         Time.deltaTime * rotationSpeed
    //     );

    //     barrelHinge.localRotation = Quaternion.Lerp(
    //         barrelHinge.localRotation,
    //         Quaternion.Euler(ClampAngle(lookRotation.eulerAngles.x, -maxBarrelElevation, maxBarrelDepression), 0f, 0f),
    //         Time.deltaTime * rotationSpeed
    //     );
    // }

    // private float ClampAngle(float angle, float min, float max)
    // {
    //     return Mathf.Clamp(angle > 180f ? angle - 360f : angle, min, max);
    // }
}

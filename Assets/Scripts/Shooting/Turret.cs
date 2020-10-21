using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform mantlet;

    [Range(0f, 0.099f)] public float smoothness;

    public void RotateTo(float yaw, float pitch)
    {
        float realSmoothness = 0.1f - smoothness;

        Vector3 targetRotation = transform.localRotation.eulerAngles;
        targetRotation.y = yaw;

        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            Quaternion.Euler(targetRotation),
            realSmoothness
        );

        Vector3 targetMantletRotation = mantlet.localRotation.eulerAngles;
        targetMantletRotation.x = pitch;

        mantlet.localRotation = Quaternion.Lerp(
            mantlet.localRotation,
            Quaternion.Euler(targetMantletRotation),
            realSmoothness
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

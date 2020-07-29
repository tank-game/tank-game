using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Rotation")]
    public Transform barrelHinge;

    [Range(1f, 10f)] public float rotationSpeed;
    [Range(0f, 90f)] public float maxBarrelElevation;
    [Range(0f, 45f)] public float maxBarrelDepression;

    [Header("Shooting")]
    public Transform muzzle;
    public GameObject round;

    // The time (in seconds) for the turret to reload
    [Range(0f, 10f)] public float reloadTime;

    // The speed at which rounds are shot (in metres/second)
    [Range(0f, 250f)] public float power;

    private float nextShootTime;

    public void AimAt(Vector3 point)
    {
        Quaternion lookRotation = Quaternion.LookRotation(point - transform.position, Vector3.up);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f),
            Time.deltaTime * rotationSpeed
        );

        barrelHinge.localRotation = Quaternion.Lerp(
            barrelHinge.localRotation,
            Quaternion.Euler(ClampAngle(lookRotation.eulerAngles.x, -maxBarrelElevation, maxBarrelDepression), 0f, 0f),
            Time.deltaTime * rotationSpeed
        );
    }

    public void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            GameObject spawnedRound = Instantiate(
                round,
                muzzle.position,
                barrelHinge.rotation
            );

            spawnedRound.GetComponent<Rigidbody>().velocity = muzzle.transform.forward * power;

            // Automatically reloads the turret
            nextShootTime = Time.time + reloadTime;
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        return Mathf.Clamp(angle > 180f ? angle - 360f : angle, min, max);
    }
}

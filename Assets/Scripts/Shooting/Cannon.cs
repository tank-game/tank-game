using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform muzzle;
    public GameObject barrel;

    public GameObject round;

    // The time (in seconds) for the cannon to reload
    [Range(0f, 10f)] public float reloadTime;

    // The speed at which rounds are shot (in metres per second)
    [Range(0f, 250f)] public float power;

    public GameObject explosionEffect;

    private float nextShootTime;

    public void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            GameObject spawnedRound = Instantiate(
                round,
                muzzle.position,
                Quaternion.identity
            );

            spawnedRound.GetComponent<Rigidbody>().velocity = barrel.transform.forward * power;

            // Automatically reloads the cannon
            nextShootTime = Time.time + reloadTime;
        }
    }
}

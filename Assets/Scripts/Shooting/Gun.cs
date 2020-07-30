using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Magazine")]
    public GameObject round;

    [Range(1f, 50f)] public int initialAmmo;

    // The time (in seconds) that it takes to load a new magazine
    [Range(1f, 10f)] public float reloadTime;

    private int remainingAmmo;

    [Header("Shooting")]
    public Transform muzzle;

    // The speed at which rounds are shot (in metres/second)
    [Range(0f, 250f)] public float power;

    // The number of rounds shot per second when constantly firing
    [Range(1f, 20f)] public float fireRate;

    private float nextShootTime;
    private bool reloading;

    void Start()
    {
        remainingAmmo = initialAmmo;
    }

    void Update()
    {
        if (reloading && Time.time >= nextShootTime)
        {
            remainingAmmo = initialAmmo;
            reloading = false;
        }
    }

    public void Shoot()
    {
        if (Time.time >= nextShootTime && remainingAmmo > 0)
        {
            GameObject spawnedRound = Instantiate(
                round,
                muzzle.position,
                Quaternion.identity
            );
            spawnedRound.GetComponent<Rigidbody>().velocity = muzzle.transform.forward * power;

            remainingAmmo -= 1;
            if (remainingAmmo > 0)
            {
                nextShootTime = Time.time + 1f / fireRate;
            }
            else
            {
                Reload();
            }
        }
    }

    public void Reload()
    {
        nextShootTime = Time.time + reloadTime;
        reloading = true;
    }
}

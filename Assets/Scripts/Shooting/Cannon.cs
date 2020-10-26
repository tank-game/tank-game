using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject round;
    public Transform muzzle;

    [Range(0f, 250f)] public float power;
    [Range(1f, 10f)] public float reloadTime;

    private float nextShootTime;
    private Vector3 lastRayHitPoint;

    void Start()
    {
        lastRayHitPoint = Vector3.zero;
    }

    public void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            GameObject spawnedRound = Instantiate(
                round,
                muzzle.position,
                Quaternion.identity
            );
            spawnedRound.GetComponent<Rigidbody>().velocity = muzzle.forward * power;

            nextShootTime = Time.time + reloadTime;
        }
    }

    public float LoadingProgress()
    {
        float timeUntilNextLoad = Mathf.Clamp(nextShootTime - Time.time, 0f, reloadTime);
        return 1f - (timeUntilNextLoad / reloadTime);
    }

    public Vector3 RayPoint()
    {
        RaycastHit hit;

        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit))
        {
            lastRayHitPoint = hit.point;
        }

        return lastRayHitPoint;
    }
}

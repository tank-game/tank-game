﻿using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject round;
    public Transform muzzle;

    

    [Range(0f, 1000f)] public float power;
    [Range(1f, 100f)] public float reloadTime;

    private float nextShootTime;

    Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
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
            m_animator.SetTrigger("Shoot");
            spawnedRound.GetComponent<Rigidbody>().velocity = muzzle.forward * power;

            nextShootTime = Time.time + reloadTime;
        }
    }

    public float LoadingProgress()
    {
        float timeUntilNextLoad = Mathf.Clamp(nextShootTime - Time.time, 0f, reloadTime);
        return 1f - (timeUntilNextLoad / reloadTime);
    }
}

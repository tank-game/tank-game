using UnityEngine;

public class Target : MonoBehaviour
{
    public float initialHealth;
    [Range(0f, 1f)] public float damageReduction;

    public bool destroyOnDeath;

    private float remainingHealth;

    void Start()
    {
        remainingHealth = initialHealth;
    }

    void Update()
    {
        if (remainingHealth <= 0f)
        {
            enabled = false;
            if (destroyOnDeath) { Destroy(gameObject); }
        }
    }

    public void Hit(float damage)
    {
        remainingHealth -= damage * (1f - damageReduction);
    }
}

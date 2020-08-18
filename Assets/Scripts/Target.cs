using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float initialHealth;
    public bool destroyOnDeath;

    public Slider healthBar;

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

        if (healthBar)
        {
            healthBar.value = remainingHealth / initialHealth;
        }
    }

    public void Hit(float damage)
    {
        remainingHealth -= damage;
    }
}

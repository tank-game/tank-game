using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Barrel")
        {
            Target target = other.gameObject.GetComponent<Target>();
            if (target)
            {
                target.Hit(damage);
            }
        }
    }
}

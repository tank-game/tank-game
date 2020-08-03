using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosionEffect;

    public float blastRadius;
    public float explosionForce;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Barrel")
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);

            foreach (Collider nearbyObject in Physics.OverlapSphere(transform.position, blastRadius))
            {
                Target target = nearbyObject.GetComponent<Target>();
                if (target)
                {
                    target.Hit(explosionForce);
                }

                Rigidbody rigidbody = nearbyObject.GetComponent<Rigidbody>();
                if (rigidbody)
                {
                    rigidbody.AddExplosionForce(explosionForce, transform.position, blastRadius);
                }
            }

            Destroy(gameObject);
        }
    }
}

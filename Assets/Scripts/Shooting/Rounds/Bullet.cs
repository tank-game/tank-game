using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Barrel")
        {
            Debug.Log("Hit " + other.gameObject.name + "!");
        }
    }
}

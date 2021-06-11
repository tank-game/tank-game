using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Barrel")
        {
            ArmourPlate armourPlate = other.gameObject.GetComponent<ArmourPlate>();
            if (armourPlate)
            {
                armourPlate.Hit(damage);
            }
        }
    }
}

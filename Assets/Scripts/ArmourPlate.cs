using UnityEngine;

public class ArmourPlate : MonoBehaviour
{
    public Target parentTarget;

    [Range(0f, 1f)] public float damageReduction;

    public void Hit(float damage)
    {
        parentTarget.Hit(damage * (1f - damageReduction));
    }
}

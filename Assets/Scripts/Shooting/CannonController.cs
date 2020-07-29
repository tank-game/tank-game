using UnityEngine;

public class CannonController : RangedWeaponController
{
    public Cannon cannon;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cannon.Shoot();
        }
    }
}

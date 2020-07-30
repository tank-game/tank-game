using UnityEngine;

public class CannonController : WeaponController
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

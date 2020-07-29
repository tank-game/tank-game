using UnityEngine;

public class GunController : RangedWeaponController
{
    public Gun gun;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gun.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.Reload();
        }
    }
}

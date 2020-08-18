using UnityEngine;
using TMPro;

public class GunController : WeaponController
{
    public Gun gun;

    public TextMeshProUGUI ammoIndicator;

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

        ammoIndicator.text = gun.remainingAmmo.ToString() + " / " + gun.initialAmmo.ToString();
    }
}

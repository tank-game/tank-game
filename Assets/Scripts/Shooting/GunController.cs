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

    public override void Equip()
    {
        this.enabled = true;
        ammoIndicator.gameObject.SetActive(true);
    }

    public override void Unequip()
    {
        this.enabled = false;
        ammoIndicator.gameObject.SetActive(true);
    }
}

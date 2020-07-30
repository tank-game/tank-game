using UnityEngine;

public class WeaponRack : MonoBehaviour
{
    public WeaponController[] weaponControllers;

    private int activeWeaponController;

    void Start()
    {
        activeWeaponController = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) { ToggleWeapon(); }

        for (int i = 0; i < weaponControllers.Length; i++)
        {
            weaponControllers[i].enabled = i == activeWeaponController;
        }
    }

    private void ToggleWeapon()
    {
        if (activeWeaponController == weaponControllers.Length - 1)
        {
            activeWeaponController = 0;
        }
        else
        {
            activeWeaponController += 1;
        }
    }
}

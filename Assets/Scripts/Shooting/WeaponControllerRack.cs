using UnityEngine;

public class WeaponControllerRack : MonoBehaviour
{
    public WeaponController[] weaponControllers;

    private int activeWeaponControllerIndex;

    void Start()
    {
        activeWeaponControllerIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) { ToggleWeapon(); }

        print(activeWeaponControllerIndex);
        for (int i = 0; i < weaponControllers.Length; i++)
        {
            if (i == activeWeaponControllerIndex)
            {
                weaponControllers[i].Equip();
            }
            else
            {
                weaponControllers[i].Unequip();
            }
        }
    }

    private void ToggleWeapon()
    {
        if (activeWeaponControllerIndex == weaponControllers.Length - 1)
        {
            activeWeaponControllerIndex = 0;
        }
        else
        {
            activeWeaponControllerIndex += 1;
        }
    }
}

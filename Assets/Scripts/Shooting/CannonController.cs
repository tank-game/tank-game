using UnityEngine;
using UnityEngine.UI;

public class CannonController : WeaponController
{
    public Cannon cannon;

    public Slider loadingIndicator; // TODO: Rename?

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cannon.Shoot();
        }

        loadingIndicator.value = cannon.LoadingProgress();
    }

    public override void Equip()
    {
        this.enabled = true;
        loadingIndicator.value = cannon.LoadingProgress();
        loadingIndicator.gameObject.SetActive(true);
    }

    public override void Unequip()
    {
        this.enabled = false;
        loadingIndicator.gameObject.SetActive(false);
    }
}

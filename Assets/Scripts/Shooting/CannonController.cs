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
}

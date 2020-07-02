using UnityEngine;

public class CannonController : MonoBehaviour
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

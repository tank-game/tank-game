using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Turret turret;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            turret.AimAt(hit.point);
        }

        if (Input.GetMouseButton(0))
        {
            turret.Shoot();
        }
    }
}

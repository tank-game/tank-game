using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Turret turret;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            turret.AimAt(hit.point);
        }

        if (Input.GetMouseButton(0))
        {
            turret.Shoot();
        }
    }
}

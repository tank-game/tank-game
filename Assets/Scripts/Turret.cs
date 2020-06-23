using UnityEngine;

public class Turret : MonoBehaviour
{
    [Range(0.01f, 10f)] public float rotationSpeed;
    public Transform barrelHinge;
    [Range(0f, 90f)] public float maxBarrelElevation;
    [Range(0f, 45f)] public float maxBarrelDepression;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Quaternion lookRotation = Quaternion.LookRotation(hit.point - transform.position, Vector3.up);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f),
                Time.deltaTime * rotationSpeed
            );

            barrelHinge.localRotation = Quaternion.Lerp(
                barrelHinge.localRotation,
                Quaternion.Euler(ClampAngle(lookRotation.eulerAngles.x, -maxBarrelElevation, maxBarrelDepression), 0f, 0f),
                Time.deltaTime * rotationSpeed
            );
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        angle = (angle > 180f) ? angle - 360 : angle;
        return Mathf.Clamp(angle, min, max);
    }
}

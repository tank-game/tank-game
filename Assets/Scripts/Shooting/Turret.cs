using UnityEngine;

public class Turret : MonoBehaviour
{
    [Range(1f, 10f)] public float rotationSpeed;
    public Transform barrelHinge;
    [Range(0f, 90f)] public float maxBarrelElevation;
    [Range(0f, 45f)] public float maxBarrelDepression;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            LookTowards(hit.point);
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        angle = (angle > 180f) ? angle - 360f : angle;
        return Mathf.Clamp(angle, min, max);
    }

    private void LookTowards(Vector3 point)
    {
        Quaternion lookRotation = Quaternion.LookRotation(point - transform.position, Vector3.up);

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

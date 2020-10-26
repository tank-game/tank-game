using UnityEngine;
using UnityEngine.UI;

public class Reticule : MonoBehaviour
{
    public RawImage reticule;
    public Cannon cannon;
    public Camera cam;

    public float smoothness;

    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(cannon.RayPoint());
        reticule.transform.position = Vector3.Lerp(
            transform.position,
            screenPos,
            smoothness
        );
    }
}

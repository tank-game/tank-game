using UnityEngine;

public class Sprocket : MonoBehaviour
{
    public Transform model;

    public void Spin(float speed)
    {
        model.Rotate(Vector3.right * speed);
    }
}

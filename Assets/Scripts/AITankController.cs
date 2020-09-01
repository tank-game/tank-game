using UnityEngine;

public class AITankController : MonoBehaviour
{
    public Tank tank;

    public Radar radar;
    public GameObject detectionIndicator;

    private GameObject targetPlayer;

    void Update()
    {
        GameObject closestPlayer = radar.FindClosestPlayer();
        if (closestPlayer)
        {
            targetPlayer = radar.CanDetect(closestPlayer) ? closestPlayer : null;
        }

        detectionIndicator.SetActive(targetPlayer);
        detectionIndicator.transform.LookAt(Camera.main.transform.position);
    }

    void FixedUpdate()
    {
        // If the closest player can be detected, rotate and move towards them
        if (targetPlayer)
        {
            Vector3 relativePosition = targetPlayer.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(relativePosition);

            float relativeRotation = Mathf.DeltaAngle(transform.rotation.eulerAngles.y, lookRotation.eulerAngles.y);
            float scaledRotation = Mathf.Clamp((relativeRotation / 180f) * 5f, -1f, 1f);
            tank.Move(0f, scaledRotation);
        }
        else
        {
            // TODO: Maybe move idly about?
        }
    }
}

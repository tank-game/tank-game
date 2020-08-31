using UnityEngine;

public class AITankController : MonoBehaviour
{
    public Tank tank;

    [Range(10f, 100f)] public float detectionRange;

    private Transform currentTarget;

    void Update()
    {
        currentTarget = FindClosestPlayer();
        print(currentTarget);
    }

    private Transform FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 0)
        {
            return null;
        }
        else if (players.Length == 1)
        {
            // TODO: Extract players[0] into a variable?
            if (CanDetect(players[0]))
            {
                return players[0].transform;
            }
            else
            {
                return null;
            }
        }
        else
        {
            float lowestDistance = Vector3.Distance(transform.position, players[0].transform.position);
            GameObject closestPlayer = null;

            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < lowestDistance)
                {
                    lowestDistance = distance;
                    closestPlayer = player;
                }
            }

            return closestPlayer.transform;
        }
    }

    private bool CanDetect(GameObject player)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= detectionRange;
    }
}

using UnityEngine;

public class Radar : MonoBehaviour
{
    [Range(10f, 250f)] public float detectionRange;

    public GameObject FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 0)
        {
            return null;
        }
        else if (players.Length == 1)
        {
            // If there is only one player, it must be the closest
            return players[0];
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

            return closestPlayer;
        }
    }

    public bool CanDetect(GameObject player)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= detectionRange;
    }
}

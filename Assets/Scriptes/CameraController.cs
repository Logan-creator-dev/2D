
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawner"))
        {
            LevelManager.SpawnPoints.Add(other.transform);
        }

        if (other.CompareTag("Waypoint"))
        {
            LevelManager.Waypoints.Add(other.transform);
        }²
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Spawner"))
        {
            LevelManager.SpawnPoints.Remove(other.transform);
        }
        if (other.CompareTag("Waypoint"))
        {
            LevelManager.Waypoints.Remove(other.transform);
        }
    }
}

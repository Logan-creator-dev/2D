using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [Header("Level")] 
    [SerializeField] private float _levelSpeed;

    [Header("Spawning")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnRate;
    
    public static List<Transform> SpawnPoints = new();
    public static List<Transform> WayPoints = new();
    
    private float _spawnTimer;
    
    private void Update() {
        // Level translation
        transform.Translate(Vector2.down * (Time.deltaTime * _levelSpeed));

        // Spawner
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnRate)
        {
            if (WayPoints.Count == 0 || SpawnPoints.Count == 0) return;
                
            Transform rndPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
            GameObject instantiate = Instantiate(_prefab, rndPoint.position, rndPoint.rotation);
            instantiate.GetComponent<EnemyController>().Setup(WayPoints);
            _spawnTimer = 0;
        }
    }
}

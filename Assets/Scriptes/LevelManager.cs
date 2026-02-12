using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelManager : MonoBehaviour
{
    [Header("Level")] 
    [SerializeField] private string _seed;
    [SerializeField] private float _chunkNumber;
    [SerializeField] private float _chunkGap;
    [SerializeField] private List<GameObject> Chunks;
    [SerializeField] private float _levelSpeed;

    [Header("Spawning")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnRate;
    
    public const int  LevelSpeed = 1;
    public static List<Transform> SpawnPoints = new();
    public static List<Transform> Waypoints = new();
    public static Random Random;
    
    
    private float _spawnTimer;

    private void Awake()
    {
       Random = new Random(_seed.GetHashCode()); 
    }

    private void Start()
    {
        if (Chunks.Count == 0) return;
        
        for (int i = 0; i <= _chunkNumber; i++)
        {
            GameObject chunk = Chunks[Random.Next(0, Chunks.Count)];
            Instantiate(chunk, Vector3.up * (i * _chunkGap), Quaternion.identity,  transform);
        }
    }
    
    
    private void Update() {
        // Level translation
        transform.Translate(Vector2.down * (Time.deltaTime * _levelSpeed));

        // Spawner
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnRate)
        {
            if (Waypoints.Count == 0 || SpawnPoints.Count == 0) return;
                
            Debug.Log("Spawning at : " + Time.time);   
            Transform rndPoint = SpawnPoints[Random.Next(0, SpawnPoints.Count)];
            GameObject instantiate = Instantiate(_prefab, rndPoint.position, rndPoint.rotation, rndPoint);
            instantiate.GetComponent<EnemyController>().Setup(Waypoints);
            _spawnTimer = 0;
        }
    }
}

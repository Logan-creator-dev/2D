using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private string _seed;
    [SerializeField] private float _lifeTime;
    
    [Header("Waypoints")]
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private Transform _currentWaypoint;
    
    [Header("Waiting")]
    [SerializeField] private float _waitTimer;
    [SerializeField] private float _waitDuration = -1;
    [SerializeField] private int _minWaitDuration = 1;
    [SerializeField] private int _maxWaitDuration =5;

    private int _waypointIndex;
    private System.Random _random;

    public void Setup(List<Transform> waypoints)
    {
        _waypoints = waypoints;
        
        if (_random == null)
            _random = new System.Random(_seed.GetHashCode());
        
        if (_currentWaypoint == null &&  _waypoints.Count > 0)
            _currentWaypoint = _waypoints[_random.Next(0, _waypoints.Count)];
    }

    private void Start()
    {
        Invoke(nameof(DestroyMe), _lifeTime);
    }

    private void Update()
    {
        if (_currentWaypoint == null) return;
        
        Vector3 movement = _currentWaypoint.position - transform.position;

        //If the target is reached
        if (movement.magnitude < 0.1f) 
        {
            // Define the wait time if not defined
            if (_waitDuration < 0)
            {
                //_waitDuration = _random.Next( _minWaitDuration , _maxWaitDuration);
                _waitDuration = _random.Next(_minWaitDuration, _maxWaitDuration);
            }
            
            // If the timer is done
            if (_waitTimer >= _waitDuration)
            {
               _currentWaypoint = NextRandomWaypoint();
               
               // Reset the timer
               _waitTimer = 0;
               
               // Reset the time duration
               _waitDuration = -1;
            }
            
            else
            {
                // Play the timer
                _waitTimer += Time.deltaTime;
            }
        }
        else
        {
            // Move the enemy toward the waypoint
            transform.Translate(movement.normalized * (Time.deltaTime * _moveSpeed));
        }
    }

    private Transform NextWaypoint()
    {
        // Get the next index
        _waypointIndex++;

        // If the index overflow the list then take the first
        if (_waypointIndex >= _waypoints.Count)
            _waypointIndex = 0;
        
        // Update the current waypoint using the index
        return _waypoints[_waypointIndex];
    }

    private Transform NextRandomWaypoint()
    {
        // Get the next index
        _waypointIndex = _random.Next(0,_waypoints.Count);
        
        // Update the current waypoint using the index
        return _waypoints[_waypointIndex];
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}   

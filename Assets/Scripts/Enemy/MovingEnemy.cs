using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingEnemy : Enemy
{
    [SerializeField] private Transform[] _wayPoints;

    private Transform _currentWaypoint;
    private int _currentWaypointIndex;
    
    private void Start()
    {
        if (_wayPoints.Length > 0)
        {
            _currentWaypointIndex = 0;
            _currentWaypoint = _wayPoints[_currentWaypointIndex];
            transform.position = _currentWaypoint.position;
        }
            
    }

    protected override void Update()
    {
        base.Update();
        Debug.DrawLine(transform.position, transform.position + (_currentWaypoint.position-transform.position).normalized);
        _enemyMovement.Move((_currentWaypoint.position-transform.position).normalized, _enemySo.MovementSpeed);
        if (Vector3.Distance(transform.position, _currentWaypoint.position) <= 0.1f)
        {
            _currentWaypoint = NextWaypoint();
        }
    }

    private Transform NextWaypoint()
    {
        _currentWaypointIndex++;
        if (_currentWaypointIndex > _wayPoints.Length - 1)
        {
            _currentWaypointIndex = 0;
        }

        return _wayPoints[_currentWaypointIndex];
    }
}

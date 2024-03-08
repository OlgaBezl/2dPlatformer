using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : CharacterMover
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private Watcher _watcher;
    [SerializeField] private float _zeroDistanceToTarget = 0.3f;
    
    private Waypoint _currentWaypoint;

    private void Start()
    {
        SetCurrentWaypoint(_waypoints[0]);
    }

    private void Update()
    {
        if (IsActive == false)
        {
            return;
        }

        if (_watcher.IsWatchingTarget)
        {
            Direction = _watcher.TargetPosition;
        }
        else
        {
            if (CheckIfNearTarget(_currentWaypoint.transform.position))
            {
                SetCurrentWaypoint(GetNextWaypoint());
            }
            else
            {
                SetCurrentWaypoint(_currentWaypoint);
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsActive == false)
        {
            return;
        }

        Mover.MoveTo(Direction.normalized);
    }

    private Waypoint GetNextWaypoint()
    {
        int currentIndex = _waypoints.IndexOf(_currentWaypoint);
        int nextIndex = ++currentIndex % _waypoints.Count;

        return _waypoints[nextIndex];
    }

    private void SetCurrentWaypoint(Waypoint waypoint)
    {
        _currentWaypoint = waypoint;
        Direction = (waypoint.transform.position - transform.position).normalized;
    }

    private bool CheckIfNearTarget(Vector2 targetPosition)
    {
        float distance = Vector2.Distance(transform.position, targetPosition);
        return distance <= _zeroDistanceToTarget;
    }
}

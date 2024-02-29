using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private Mover _mover;
    [SerializeField] private Watcher _watcher;

    private Vector2 _direction;

    private void Start()
    {
        ChangeCurrentWaypoint(_waypoints[0]);
    }

    private void FixedUpdate()
    {
        if (_watcher.IsWatchingTarget)
        {
            _mover.MoveTo(_watcher.TargetPosition.normalized);
        }
        else
        {
            _mover.MoveTo(_direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Waypoint waypoint))
        {
            int currentIndex = _waypoints.IndexOf(waypoint);
            int nextIndex = ++currentIndex % _waypoints.Count;

            ChangeCurrentWaypoint(_waypoints[nextIndex]);
        }
    }

    private void ChangeCurrentWaypoint(Waypoint waypoint)
    {
        _direction = (waypoint.transform.position - transform.position).normalized;
    }
}

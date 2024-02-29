using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private Movement _movement;

    private Vector2 _direction;

    private void Start()
    {
        ChangeCurrentWaypoint(_waypoints[0]);
    }

    private void FixedUpdate()
    {
        _movement.MoveTo(_direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Waypoint waypoint))
        {
            int index = _waypoints.IndexOf(waypoint);
            int nextIndex = 0;

            if (index + 1 < _waypoints.Count)
            {
                nextIndex = index + 1;
            }

            ChangeCurrentWaypoint(_waypoints[nextIndex]);
        }
    }

    private void ChangeCurrentWaypoint(Waypoint waypoint)
    {
        _direction = (waypoint.transform.position - transform.position).normalized;
    }
}

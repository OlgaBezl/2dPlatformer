using UnityEngine;

public class Watcher : MonoBehaviour
{
    [SerializeField] private float _distanceView = 10f;
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private Transform _transform;
    [SerializeField] private Mover _mover;

    public bool IsWatchingTarget { get; private set; }
    public Vector2 TargetPosition { get; private set; }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, _mover.Direction, _distanceView, _targetLayerMask);

        if (hit.collider != null)
        {
            IsWatchingTarget = true;
            TargetPosition = hit.collider.gameObject.transform.position;
        }
        else
        {
            IsWatchingTarget = false;
        }
    }
}

using System;
using UnityEngine;

public class Mover 
{
    public event Action<bool> Walking;

    private Transform _rootTransform;
    private float _speed = 5;
    private Vector2 _direction;
    
    public Mover (Transform rootTransform, float speed)
    {
        _rootTransform = rootTransform;
        _speed = speed;
    }

    public void MoveTo(Vector2 direction)
    {
        UpdateWalkEvent(direction);
        _direction = direction;

        _rootTransform.Translate(_speed * Time.deltaTime * direction, Space.World);

        if (direction.x < 0 && _rootTransform.localScale.x > 0 ||
            direction.x > 0 && _rootTransform.localScale.x < 0)
        {
            Flip();
        }
    }

    private void UpdateWalkEvent(Vector2 direction)
    {
        if (_direction == Vector2.zero && direction != Vector2.zero)
        {
            Walking?.Invoke(true);
        }
        else if (direction == Vector2.zero && _direction != Vector2.zero)
        {
            Walking?.Invoke(false);
        }
    }

    private void Flip()
    {
        float xLocalScale = -_rootTransform.localScale.x;
        _rootTransform.localScale = new Vector3(xLocalScale, _rootTransform.localScale.y, _rootTransform.localScale.z);
    }
}
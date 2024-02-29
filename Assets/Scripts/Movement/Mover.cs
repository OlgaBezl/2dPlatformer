using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _rootTransform;
    [SerializeField] private float _speed = 5;

    public void MoveTo(Vector2 direction)
    {
        _rootTransform.Translate(_speed * Time.deltaTime * direction, Space.World);

        if (direction.x < 0 && _rootTransform.localScale.x > 0 ||
            direction.x > 0 && _rootTransform.localScale.x < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        float xLocalScale = -_rootTransform.localScale.x;
        _rootTransform.localScale = new Vector3(xLocalScale, _rootTransform.localScale.y, _rootTransform.localScale.z);
    }
}
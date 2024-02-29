using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private float _attackValue = 10f;
    [SerializeField] private float _cooldown = 3f;

    private float _timeAfterStartAttack;
    public bool IsAttack {  get; private set; }

    private void Update()
    {
        _timeAfterStartAttack += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CheckIfCollisionInTargetLayer(collision))
        {
            if (_timeAfterStartAttack > _cooldown)
            {
                if (collision.TryGetComponent(out Health health))
                {
                    health.TakeDamage(_attackValue);
                    IsAttack = true;
                    _timeAfterStartAttack = 0;
                }
            }                
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckIfCollisionInTargetLayer(collision))
        {
            IsAttack = false;
        }
    }

    private bool CheckIfCollisionInTargetLayer(Collider2D collision)
    {
        return 1 << collision.gameObject.layer == _targetLayerMask.value;
    }
}

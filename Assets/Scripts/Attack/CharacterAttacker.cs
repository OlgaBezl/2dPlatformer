using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CharacterAttacker : Attacker
{
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Died += DisableComponent;
    }

    private void OnDisable()
    {
        _health.Died -= DisableComponent;
        _health.Died -= StopAttack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckIfCollisionInTargetLayer(collision))
        {
            if (collision.TryGetComponent(out Health health))
            {
                if(health.IsAlive)
                {
                    TryAttack(health);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckIfCollisionInTargetLayer(collision))
        {
            if (collision.TryGetComponent(out Health _))
            {
                StopAttack();
            }
        }
    }

    private bool CheckIfCollisionInTargetLayer(Collider2D collision)
    {
        return 1 << collision.gameObject.layer == _targetLayerMask.value;
    }

    private void DisableComponent()
    {
        OnDisable();
        GetComponent<Collider2D>().enabled = false;
    }
}


using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CharacterAttacker : Attacker
{
    [SerializeField] private LayerMask _targetLayerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckIfCollisionInTargetLayer(collision))
        {
            if (collision.TryGetComponent(out Health health))
            {
                if(health.CurrentHealth > 0)
                {
                    TryAttack(health);
                }
                else
                {
                    StopAttack();
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
}

using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Attacker _attacker;

    public readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));

    private void FixedUpdate()
    {
        _animator.SetBool(IsAttack, _attacker.IsAttack);
    }
}

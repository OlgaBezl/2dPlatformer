using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{    
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private Attacker _attacker;

    public readonly int IsWalk = Animator.StringToHash(nameof(IsWalk));
    public readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));

    private void FixedUpdate()
    {
        _animator.SetBool(IsWalk, _playerMovement.IsWalk);
        _animator.SetBool(IsAttack, _attacker.IsAttack);
    }
}

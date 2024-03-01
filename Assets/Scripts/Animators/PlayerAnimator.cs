using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{    
    [SerializeField] private PlayerMover _playerMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private Attacker _attacker;

    public readonly int IsWalk = Animator.StringToHash(nameof(IsWalk));
    public readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    public readonly int IsDie = Animator.StringToHash(nameof(IsDie));

    private bool _isAlive;

    private void FixedUpdate()
    {
        if (_isAlive)
        {
            _animator.SetBool(IsWalk, _playerMovement.IsWalk);
            _animator.SetBool(IsAttack, _attacker.IsAttack);
        }
    }

    public void PlayDie()
    {
        Debug.Log("PlayDie");
        _isAlive = false;
        _animator.SetBool(IsDie, true);
    }
}

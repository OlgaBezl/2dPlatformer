using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{    
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animator _animator;

    public readonly int IsWalk = Animator.StringToHash(nameof(IsWalk));

    private void FixedUpdate()
    {
        _animator.SetBool(IsWalk, _playerMovement.IsWalk);
    }
}

using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    [SerializeField] private CharacterMover _mover;

    public readonly int IsWalk = Animator.StringToHash(nameof(IsWalk));
    public readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    public readonly int IsDie = Animator.StringToHash(nameof(IsDie));

    private void OnEnable()
    {
        _attacker.Attacking += PlayAttack;
        _health.Died += PlayDie;
        _mover.Walking += PlayWalk;
    }

    private void OnDisable()
    {
        _attacker.Attacking -= PlayAttack;
        _health.Died -= PlayDie;
        _mover.Walking -= PlayWalk;
    }

    private void PlayWalk(bool on)
    {
        _animator.SetBool(IsWalk, on);
    }

    private void PlayAttack(bool on)
    {
        _animator.SetBool(IsAttack, on);
    }

    private void PlayDie()
    {
        OnDisable();
        _animator.SetBool(IsDie, true);
    }
}

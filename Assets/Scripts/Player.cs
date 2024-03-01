using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private CharacterAttacker _attacker;
    [SerializeField] private Jump _jump;
    [SerializeField] private PlayerAnimator _playerAnimator;

    public bool IsDie { get; private set; }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public void Die()
    {
        _jump.gameObject.SetActive(false);
        _attacker.gameObject.SetActive(false);
        IsDie = true;
        _playerAnimator.PlayDie();
    }
}

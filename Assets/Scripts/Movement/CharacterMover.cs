using System;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Transform _rootTransform;
    [SerializeField] private float _speed = 5;
    [SerializeField] private CharacterHealth _health;

    public event Action<bool> Walking;

    protected MovementInput Input;
    protected Mover Mover;
    protected bool IsActive;

    public Vector2 Direction {  get; protected set; }

    private void Awake()
    {
        Input = new MovementInput();
        Mover = new Mover(_rootTransform, _speed);
        Mover.Walking += Walking;
        IsActive = true;
    }

    private void OnEnable()
    {
        _health.Died += Stop;
    }

    private void OnDisable()
    {
        _health.Died -= Stop;
        Mover.Walking -= Walking;
    }

    private void Stop()
    {
        IsActive = false;
        Mover.MoveTo(Vector2.zero);
        OnDisable();
    }
}

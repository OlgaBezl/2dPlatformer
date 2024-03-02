using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action Died;

    private Health _health;

    public bool IsAlive { get => _health.CurrentHealth > 0; }

    private void Start()
    {
        _health= new Health(_maxHealth);
        _health.Died += Died;
    }

    private void OnDisable()
    {
        _health.Died -= Died;
    }

    public void Heal(float value)
    {
        _health.Heal(value);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}

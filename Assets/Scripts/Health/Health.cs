using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action Died;

    public float CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void Heal(float value)
    {
        if(value > 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, _maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxHealth);

            if (CurrentHealth <= 0)
            {
                Died?.Invoke();
            }
        }
    }
}

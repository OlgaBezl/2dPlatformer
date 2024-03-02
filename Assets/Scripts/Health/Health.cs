
using System;
using UnityEngine;

public class Health
{
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    public event Action Died;

    public Health(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void Heal(float value)
    {
        if (value > 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, MaxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);

            if (CurrentHealth <= 0)
            {
                Died?.Invoke();
            }
        }
    }
}

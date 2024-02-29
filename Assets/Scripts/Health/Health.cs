using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public float CurrentHealth { get => _currentHealth; }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
    }
}

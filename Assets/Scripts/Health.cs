using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    int _currentHealth;

    public int MaxHealth => _maxHealth;

    public event Action<int, int> OnHealthChanged;

    public void OnCreated()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        int previousHealth = _currentHealth;
        _currentHealth -= damage;

        OnHealthChanged?.Invoke(previousHealth, _currentHealth);
    }
}
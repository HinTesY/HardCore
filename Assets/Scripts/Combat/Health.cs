using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    private bool _isDead = false;

    public event Action OnDeath;
    public event Action<float> OnHealthChanged;
    public float CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        if (_isDead) return;
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, _maxHealth);
        OnHealthChanged?.Invoke(_currentHealth);
        if (_currentHealth <= 0) { _isDead = true; OnDeath?.Invoke(); } 
    }
}

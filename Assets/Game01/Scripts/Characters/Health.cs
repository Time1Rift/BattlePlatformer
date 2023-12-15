using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private Dead _dead;
    [SerializeField] private UnityEvent _healPlayer;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public event Action HealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void OnValidate()
    {
        int minValue = 1;

        if (_maxHealth <= 0)
            _maxHealth = minValue;
    }

    public void Take(float damage)
    {
        float timerDeath = 0.5f;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            HealthChanged?.Invoke();
            Invoke(nameof(Die), timerDeath);            
        }
        else
        {
            HealthChanged?.Invoke();
        }
    }

    public bool CanHeal() => _currentHealth < _maxHealth;

    public void Heal(float powerHeal)
    {
        if (_currentHealth + powerHeal >= _maxHealth)
            _currentHealth = _maxHealth;
        else
            _currentHealth += powerHeal;

        _healPlayer?.Invoke();
        HealthChanged?.Invoke();
    }

    private void Die()
    {
        Instantiate(_dead, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
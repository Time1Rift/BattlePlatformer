using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private Dead _dead;
    [SerializeField] private UnityEvent _healPlayer;

    private int _powerHeal = 10;
    private int _currentHealth;

    public int CurrentHealth => _currentHealth;
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

    public void SetHurt(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            HealthChanged?.Invoke();
            Instantiate(_dead, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        HealthChanged?.Invoke();
    }

    public bool CanHeal() => _currentHealth < _maxHealth;

    public void Heal(Collider2D collider)
    {
        if (_currentHealth + _powerHeal >= _maxHealth)
            _currentHealth = _maxHealth;
        else
            _currentHealth += _powerHeal;

        _healPlayer?.Invoke();
        HealthChanged?.Invoke();
    }
}
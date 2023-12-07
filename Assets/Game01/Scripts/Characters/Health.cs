using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private Dead _dead;
    [SerializeField] private UnityEvent _healPlayer;

    private int _powerHeal = 1;
    private int _currentHealth;

    public int CurrentHealth { get; private set; }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void GetHurt()
    {
        _currentHealth--;

        if (_currentHealth <= 0)
        {
            Instantiate(_dead, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public bool CanHeal() => _currentHealth + _powerHeal <= _maxHealth;

    public void Heal(Collider2D collider)
    {
            _currentHealth += _powerHeal;
            _healPlayer?.Invoke();
    }
}
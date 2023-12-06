using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private Dead _dead;

    private int _currentHealth = 2;
    private Enemy _parentEnemy;

    private void Awake()
    {
        _parentEnemy = GetComponentInParent<Enemy>();
    }

    public void TakeDamage()
    {
        _currentHealth--;

        if (_currentHealth <= 0)
        {
            Instantiate(_dead, transform.position, Quaternion.identity);
            Destroy(_parentEnemy.gameObject);
        }
    }
}
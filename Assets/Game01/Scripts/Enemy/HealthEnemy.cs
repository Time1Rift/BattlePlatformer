using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    private int _maxHealth = 2;
    private int _currentHealth = 2;

    public void TakeDamage()
    {
        _currentHealth--;

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }
}
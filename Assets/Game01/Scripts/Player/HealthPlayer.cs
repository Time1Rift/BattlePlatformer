using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent _healPlayer;

    private int _maxHealth = 3;
    private int _currentHealth = 3;

    public void TakeDamage()
    {
        _currentHealth--;

        if (_currentHealth <= 0)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int heal = 1;

        if (collision.GetComponent<FirstAidKit>())
        {
            if (_currentHealth + heal <= _maxHealth)
            {
                _healPlayer?.Invoke();
                Destroy(collision.gameObject);
                _currentHealth++;
            }
        }
    }
}
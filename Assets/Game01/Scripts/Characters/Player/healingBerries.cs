using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealingBerries : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Berry>(out Berry berry))
        {
            if (_health.CanHeal() && berry._isUsed == false)
            {
                berry.Use();
                Destroy(collision.gameObject);
                _health.Heal(collision);
            }
        }
    }
}

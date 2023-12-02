using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<HealthEnemy>(out HealthEnemy enemy))
        {
            enemy.TakeDamage();
        }
    }
}
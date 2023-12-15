using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    private int _abilityForce = 10;
    private Health _health;

    private void Awake()
    {
        _health = GetComponentInParent<Health>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MoverEnemy enemy))
        {
            Health _enemyHeailth = enemy.GetComponent<Health>();
            float damageInTick = _abilityForce * Time.fixedDeltaTime;
            
            _enemyHeailth.Take(damageInTick);
            _health.Heal(damageInTick);
        }
    }
}
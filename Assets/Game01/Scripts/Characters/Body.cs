using UnityEngine;

public class Body : MonoBehaviour
{
    private Health _healthParent;

    private void Awake()
    {
        _healthParent = GetComponentInParent<Health>();
    }

    public void TakeDamage(float damage) => _healthParent.Take(damage);
}
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealingBerries : MonoBehaviour
{
    [SerializeField] private int _powerHeal = 10;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void HealBerry() => _health.Heal(_powerHeal);

    public bool CanHealBerry() => _health.CanHeal();
}

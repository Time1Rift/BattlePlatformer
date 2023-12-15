using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TypesLayers _purposeAttack = (TypesLayers)8;

    private float _abilityDuration = 6f;
    private float _abilityCooldown = 10f;
    private int _abilityForce = 10;
    private Health _health;
    private Collider2D _collider2D;
    private Coroutine _launchCooldown;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _health = GetComponentInParent<Health>();
        _collider2D.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemy) && enemy.gameObject.layer == (int)_purposeAttack)
            UseAbility(enemy);
    }

    public void OnClickAbility()
    {
        if (_launchCooldown != null)
            StopCoroutine(_launchCooldown);

        _launchCooldown = StartCoroutine(LaunchCooldown());
    }

    private void UseAbility(Health enemy)
    {
        Health _enemyHeailth = enemy;
        float damageInTick = _abilityForce * Time.fixedDeltaTime;

        _enemyHeailth.Take(damageInTick);
        _health.Heal(damageInTick);
    }

    private IEnumerator LaunchCooldown()
    {
        WaitForSeconds abilityDuration = new WaitForSeconds(_abilityDuration);
        WaitForSeconds abilityCooldown = new WaitForSeconds(_abilityCooldown);

        _button.interactable = false;
        _collider2D.enabled = true;

        yield return abilityDuration;
        _collider2D.enabled = false;

        yield return abilityCooldown;
        _button.interactable = true;
    }
}
using UnityEngine;

public class Berry : MonoBehaviour
{
    private bool _isUsed  = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealingBerries healingBerries) == false)
            return;

        if(_isUsed == false && healingBerries.CanHealBerry())
        {
            Use();
            Destroy(gameObject);
            healingBerries.HealBerry();
        }
    }

    private void Use() => _isUsed = true;
}
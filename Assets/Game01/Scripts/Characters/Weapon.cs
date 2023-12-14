using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private int _invulnerability = 3;
    private int _value;

    private void Start()
    {
        _value = _invulnerability;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _value++;

        if (collision.TryGetComponent<Body>(out Body player))
        {
            if (_invulnerability <= _value)
            {
                player.TakeDamage(_damage);
                _value = 0;
            }
        }
    }
}
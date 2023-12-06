using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
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
                player.TakeDamage();
                _value = 0;
            }
        }
    }
}
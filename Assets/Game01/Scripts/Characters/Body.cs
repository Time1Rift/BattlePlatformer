using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private Health _healthParent;

    private void Awake()
    {
        _healthParent = GetComponentInParent<Health>();
    }

    public void TakeDamage() => _healthParent.GetHurt();
}
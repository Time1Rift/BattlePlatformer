using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionGems : MonoBehaviour
{
    [SerializeField] private UnityEvent _hitGem;

    private int _countGems;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Gem gem))
        {
            _countGems++;
            Debug.Log(_countGems);
            _hitGem?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
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
            _hitGem?.Invoke();
            _countGems++;
            Destroy(collision.gameObject);
        }
    }
}
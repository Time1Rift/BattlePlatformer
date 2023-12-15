using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class IsGround : MonoBehaviour
{
    [SerializeField] private Vector2 _sizeBox = new Vector2(1.1f, 0.13f);
    [SerializeField] private LayerMask _groundMask;

    private float _angleBox = 0; 
    private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public bool IsGrouded()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(new Vector2(_boxCollider.bounds.center.x, _boxCollider.bounds.min.y), _sizeBox, _angleBox, _groundMask);

        return hits.Length > 0;
    }
}
using UnityEngine;

[RequireComponent(typeof(PatrollingEnemy))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoverEnemy : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;

    private PatrollingEnemy _patrollingEnemy;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _patrollingEnemy = GetComponent<PatrollingEnemy>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Movement(Vector2 target)
    {
        _patrollingEnemy.enabled = false;
        _transform.position = Vector3.MoveTowards(_transform.position, target, _speed * Time.deltaTime);

        _spriteRenderer.flipX = _transform.position.x < target.x ? true : false;
    }
}

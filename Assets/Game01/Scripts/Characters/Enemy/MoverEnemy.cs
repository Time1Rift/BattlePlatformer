using UnityEngine;

[RequireComponent(typeof(PatrollingEnemy))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PatrollingEnemy _patrollingEnemy;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _patrollingEnemy = GetComponent<PatrollingEnemy>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Movement(Vector2 target)
    {
        _patrollingEnemy.enabled = false;
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        _spriteRenderer.flipX = transform.position.x < target.x ? true : false;
    }
}

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PatrollingEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        Vector3 target = _points[_currentPoint].position;
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        _spriteRenderer.flipX = transform.position.x < target.x ? true : false;

        if (transform.position == target)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;
        }
    }
}

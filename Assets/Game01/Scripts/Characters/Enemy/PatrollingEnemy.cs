using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PatrollingEnemy : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;
    [SerializeField] private Transform _path;

    private SpriteRenderer _spriteRenderer;
    private Vector3[] _points;
    private int _currentPoint;
    private Vector3 _target;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = new Vector3[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i).position;
    }

    private void Update()
    {
        _target = _points[_currentPoint];
        _transform.position = Vector3.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);

        _spriteRenderer.flipX = _transform.position.x < _target.x ? true : false;

        if (_transform.position == _target)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;
        }
    }
}

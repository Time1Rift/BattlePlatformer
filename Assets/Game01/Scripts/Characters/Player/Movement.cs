using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(IsGround))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speedMove = 5;
    [SerializeField] private float _jumpForce = 8;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private IsGround _isGround;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _isGround = GetComponent<IsGround>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isGround.IsGrouded())
        {
            _animator.SetBool(AnimatorController.IsJump, false);
            Move();

            if (Input.GetKeyDown(KeyCode.Space))
                JumpUp();
        }
        else
        {
            _animator.SetBool(AnimatorController.IsRun, false);
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(Horizontal);

        if (horizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool(AnimatorController.IsRun, true);
        }
        else if (horizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool(AnimatorController.IsRun, true);
        }
        else if (horizontalInput == 0)
        {
            _animator.SetBool(AnimatorController.IsRun, false);
        }

        _rigidbody2D.velocity = new Vector2(horizontalInput * _speedMove, _rigidbody2D.velocity.y);
    }

    private void JumpUp()
    {
        _animator.SetBool(AnimatorController.IsJump, true);
        _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
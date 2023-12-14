using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(IsGround))]
public class Movement : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    [SerializeField] private float _speedMove = 5;
    [SerializeField] private float _jumpForce = 8;
    [SerializeField] private float _gravityForce = 9.8f;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private IsGround _isGround;

    private Vector2 _moveDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _isGround = GetComponent<IsGround>();
    }

    private void Update()
    {
        if (_isGround.IsGrouded())
        {
            Move();

            if (Input.GetButton(Jump))
                JumpUp();
        }

        _moveDirection.y -= _gravityForce * Time.deltaTime;
        transform.Translate(_moveDirection * Time.deltaTime);

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            _animator.SetBool(AnimatorController.IsRun, false);

        if (!Input.GetKey(KeyCode.Space))
            _animator.SetBool(AnimatorController.IsJump, false);
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

        Vector2 inputDirection = new Vector2(horizontalInput, 0);
        inputDirection = transform.TransformDirection(inputDirection);
        _moveDirection = inputDirection * _speedMove;
    }

    private void JumpUp()
    {
        _animator.SetBool(AnimatorController.IsRun, false);
        _animator.SetBool(AnimatorController.IsJump, true);
        _moveDirection.y = _jumpForce;
    }
}
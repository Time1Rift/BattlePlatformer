using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody2D _rigidBody2D;
    private bool _isGround;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject)
            _isGround = true;
    }

    private void Update()
    {
        if (_isGround && Input.GetKey(KeyCode.Space))
        {
            _animator.SetBool(AnimatorController.IsJump, true);
            _rigidBody2D.AddForce(Vector2.up * _jumpForce);
            _isGround = false;
        }

        if (!Input.GetKey(KeyCode.Space))
            _animator.SetBool(AnimatorController.IsJump, false);
    }
}
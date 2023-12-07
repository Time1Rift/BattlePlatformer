using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool(AnimatorController.IsRun, true);
            transform.Translate(_speedMove * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool(AnimatorController.IsRun, true);
            transform.Translate(_speedMove * Time.deltaTime * -1, 0, 0);
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            _animator.SetBool(AnimatorController.IsRun, false);
    }
}
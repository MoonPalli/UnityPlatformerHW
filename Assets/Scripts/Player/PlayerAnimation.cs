using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        _animator.Play("IDLE");
    }

    public void Run(float value)
    {
        _animator.Play("Run");
        FlipSprite(value);
    }

    public void Jump(float value)
    {
        _animator.Play("Jump");
        FlipSprite(value);
    }

    private void FlipSprite(float value)
    {
        if (value > 0)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
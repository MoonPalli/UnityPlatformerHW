using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation), typeof(Player), typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidBody;
    private PlayerAnimation _playerAnimation;
    private Player _player;

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    public void Stand()
    {
        if (_player.OnGround)
            _playerAnimation.Idle();
    }

    public void MoveRight()
    {
        Move(_speed);
    }

    public void MoveLeft()
    {
        Move(-_speed);
    }

    public void TryJump()
    {
        if (_player.Jump)
            Jump();
    }

    private void Jump()
    {
        _rigidBody.velocity = new Vector2(0, 0);
        _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);

        if (!_player.OnGround)
            _player.UseExtraJump();
    }

    private void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        PlayAnimation(speed);
    }
    
    private void PlayAnimation(float speed)
    {
        if (_player.OnGround)
            _playerAnimation.Run(speed);
        else
            _playerAnimation.Jump(speed);
    }
}
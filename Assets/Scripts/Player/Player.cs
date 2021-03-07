using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] Transform _startPosition;

    public int Jumps { get; private set; }
    public bool OnGround { get; private set; }

    private void Start()
    {
        SpawnAtStartPoint();
        _coins = 0;
        Jumps = 1;
    }

    public void SpawnAtStartPoint()
    {
        transform.position = _startPosition.position;
    }

    public void UseAirJump()
    {
        Jumps = 0;
    }

    public void TakeCoin()
    {
        _coins += 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            Jumps = 2;
            OnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            Jumps = 1;
            OnGround = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] Transform _startPosition;

    public bool Jump { get; private set; }
    public bool OnGround { get; private set; }

    private void Start()
    {
        SpawnAtStartPoint();
        _coins = 0;
        Jump = true;
    }

    public void SpawnAtStartPoint()
    {
        transform.position = _startPosition.position;
    }

    public void UseExtraJump()
    {
        Jump = false;
    }

    public void TakeCoin()
    {
        _coins++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            Jump = true;
            OnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
            OnGround = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private SpriteRenderer _spriteRenderer;
    private int _currentPoint = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _points = new Transform[_path.transform.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        MoveToTarget(SetTargetPosition(out Transform target));
    }

    private Transform SetTargetPosition(out Transform target)
    {
        return target = _points[_currentPoint];
    }

    private void MoveToTarget(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        DirectSpriteToTarget(target);
        CheckEndPosition(target);
    }

    private void CheckEndPosition(Transform target)
    {
        if (transform.position == target.position)
        {
            _currentPoint ++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;
        }
    }

    private void DirectSpriteToTarget(Transform target)
    {
        if (target.position.x > transform.position.x)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private GameObject _objectPrefab;

    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        Initialize(_objectPrefab, _points.Length);

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _spawnPoints.GetChild(i);

        TurnOnObjects();
    }

    private void TurnOnObjects()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            if (TryGetObject(out GameObject obj))
                SetObject(obj, _points[_currentPoint].position);

            _currentPoint += 1;
        }
    }

    private void SetObject(GameObject obj, Vector2 spawnPoint)
    {
        obj.SetActive(true);
        obj.transform.position = spawnPoint;
    }
}
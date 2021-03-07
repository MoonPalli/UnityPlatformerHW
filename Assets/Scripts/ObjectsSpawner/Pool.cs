using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _objectPool = new List<GameObject>();

    protected void Initialize(GameObject prefab, int count)
    {
        for (int i = 0; i <= count - 1; i++)
        {
            GameObject objectToSpawn = Instantiate(prefab, _container.transform);
            objectToSpawn.SetActive(false);

            _objectPool.Add(objectToSpawn);
        }
    }

    protected bool TryGetObject(out GameObject obj)
    {
        obj = _objectPool.FirstOrDefault(o => o.activeSelf == false);

        return obj != null;
    }
}
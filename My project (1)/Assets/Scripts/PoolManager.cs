using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int amount = 20;

    private List<GameObject> pooledObjects = new List<GameObject>();

    private void Awake()
    {
        StartPool();
    }

    private void StartPool()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(bulletPrefab, transform);

            obj.SetActive(false);

            pooledObjects.Add(obj);
        }
    }

    public GameObject PooledGameObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
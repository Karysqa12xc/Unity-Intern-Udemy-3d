using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefabs;
    [SerializeField]
    [Range(1, 50)]int poolSize = 5;
    [SerializeField]
    [Range(0.1f, 30f)]float spawnTimer;
    GameObject[] pools;
    void Awake()
    {
        PopulatePool();
    }

    void PopulatePool()
    {
        pools = new GameObject[poolSize];
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = Instantiate(enemyPrefabs, transform);
            pools[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while(true){
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (!pools[i].activeInHierarchy)
            {
                pools[i].SetActive(true);
                return;
            }
        }
    }
}

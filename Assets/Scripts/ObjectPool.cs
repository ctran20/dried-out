using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(5, 20)] int poolSize = 5;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length;i++){
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    public void StartSpawn(int enemyNum, int spawnGap)
    {
        StartCoroutine(SpawnEnemy(enemyNum, spawnGap));
    }

    IEnumerator SpawnEnemy(int enemyNum, int spawnGap)
    {
        for(int i = 0; i < enemyNum; i++){
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnGap);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++){
            if(pool[i].activeInHierarchy == false){
                pool[i].SetActive(true);
                return;
            }
        }
    }
}

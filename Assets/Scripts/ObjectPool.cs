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

    public void StartSpawn(int enemyNum, int spawnGap, int pathNum)
    {
        StartCoroutine(SpawnEnemy(enemyNum, spawnGap, pathNum));
    }

    IEnumerator SpawnEnemy(int enemyNum, int spawnGap,int pathNum)
    {
        for(int i = 0; i < enemyNum; i++){
            EnableObjectInPool(pathNum);
            yield return new WaitForSeconds(spawnGap);
        }
    }

    private void EnableObjectInPool(int pathNum)
    {
        for(int i = 0; i < pool.Length; i++){
            if(pool[i].activeInHierarchy == false){
                pool[i].GetComponent<EnemyMover>().SetPath(pathNum);
                pool[i].SetActive(true);
                return;
            }
        }
    }
}

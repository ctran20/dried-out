using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveMaker : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] GameObject[] bossPrefab;
    [SerializeField] [Range(5, 20)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    [SerializeField] ObjectPool[] enemyPool;

    [SerializeField] List<int> currWaveInfo;

    [SerializeField] int currWave;
    [SerializeField] int waveNum;
    [SerializeField] TextAsset textAssetNames;
    string[] lines;

    private void Start()
    {
        currWave = 0;
        ReadTextFile();
        ReadCurrWaveInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartAttack(){
        int poolId;
        // currWaveInfo[currWave] pull the current wave info in a line of 5 column
        // 0      +1     +2  +3     +4
        // poolID Total  Gap StartF EndF
        // 1      10     1   0      0

        for (int i = 0; i < waveNum; i++){
            //Set ID
            poolId = currWaveInfo[currWave];

            //Set start time filler
            yield return new WaitForSeconds(currWaveInfo[currWave + 3]);

            //Start Spawn
            enemyPool[poolId].StartSpawn(currWaveInfo[currWave+1], currWaveInfo[currWave+2]);

            //Set spawn time delay + end time filler
            yield return new WaitForSeconds(currWaveInfo[(currWaveInfo[currWave + 1])*(currWaveInfo[currWave + 2]) + currWave + 4]);
        }
    }

    void ReadTextFile(){
        // How Many Enemy Attacks
        // Enemy ID and How Many and Time Gap
        // Start and End Filler Time
        // Ex:
        // 3
        // ID Total  Gap StartF EndF
        // 1  10     1   0      0
        // 4  5      5   0      0
        // 0  0      0   30     0

        lines = textAssetNames.text.Split('\n');
    }

    void ReadCurrWaveInfo(){
        waveNum = Convert.ToInt32(lines[currWave]);
        currWave++;

        for (int i = 0; i < waveNum; i++){
            foreach (string num in lines[currWave+i].Split('\t'))
            {
                Debug.Log(num);
                currWaveInfo.Add(Convert.ToInt32(num));
            };
        }
        
    }
}

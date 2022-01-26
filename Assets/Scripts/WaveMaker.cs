using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveMaker : MonoBehaviour
{
    [SerializeField] ObjectPool[] enemyPool;
    [SerializeField] List<int> currWaveInfo;
    [SerializeField] int currWave;
    [SerializeField] int currLine;
    [SerializeField] int waveNum;
    [SerializeField] TextAsset textAssetNames;
    [SerializeField] string[] lines;

    private void Start()
    {
        currWave = 0;
        currLine = 0;
        ReadTextFile();
        StartCoroutine(StartAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartAttack(){
        int poolId;
        // currWaveInfo[currWave] pull the current wave info in a line of 5 column
        // 0      +1     +2  +3     +4
        // poolID Total  Gap StartD EndD
        // 1      10     1   0      0

        ReadCurrWaveInfo();

        Debug.Log(waveNum);

        for (int i = 0; i < waveNum; i++){
            Debug.Log("Current wave: " + currWave);
            Debug.Log("Pool ID: " + currWaveInfo[currWave]);
            Debug.Log("Total enemy: " + currWaveInfo[currWave + 1]);
            Debug.Log("Spawn gap: " + currWaveInfo[currWave + 2]);
            Debug.Log("Start delay: " + currWaveInfo[currWave + 3]);
            Debug.Log("End delay: " + currWaveInfo[currWave + 4] + "\n");

            //Set ID
            poolId = currWaveInfo[currWave];

            //Set start time delay
            yield return new WaitForSeconds(currWaveInfo[currWave + 3]);

            //Start Spawn
            enemyPool[poolId].StartSpawn(currWaveInfo[currWave+1], currWaveInfo[currWave+2]);

            //Set spawn time delay + end time delay
            yield return new WaitForSeconds(currWaveInfo[currWave + 4] + (currWaveInfo[currWave + 1]) * (currWaveInfo[currWave + 2]));

            currWave += 5;
        }

        Debug.Log("\nAttack Over!\n");
    }

    void ReadTextFile(){
        // How Many Enemy Attacks
        // Enemy ID and How Many and Time Gap
        // Start and End Delay Time
        // Ex:
        // 3
        // ID Total  Gap StartF EndF
        // 1  10     1   0      0
        // 4  5      5   0      0
        // 0  0      0   30     0

        lines = textAssetNames.text.Split('\n');
    }

    void ReadCurrWaveInfo(){
        waveNum = Convert.ToInt32(lines[currLine]);
        currLine++;
        currWave = 0;
        currWaveInfo.Clear();
        
        for (int i = 0; i < waveNum; i++){
            foreach (string num in lines[currLine+i].Split('\t'))
            {
                //Debug.Log(num);
                currWaveInfo.Add(Convert.ToInt32(num));
            };
        }
        currLine += waveNum;
    }
}

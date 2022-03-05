using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveMaker : MonoBehaviour
{
    [SerializeField] int pathNum = 1;
    [SerializeField] GameObject waveButton;
    [SerializeField] ObjectPool[] enemyPool;
    [SerializeField] List<int> currAttackInfo;
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
        
    }

    public void StartAttack(){
        ReadCurrAttackInfo();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies(){
        int poolId;
        // currAttackInfo[currWave] pull the current wave info in a line of 5 column
        // 0      +1     +2  +3     +4
        // poolID Total  Gap StartD EndD
        // 1      10     1   0      0

        Debug.Log(waveNum);

        for (int i = 0; i < waveNum; i++){
            Debug.Log("Current wave: " + currWave);
            Debug.Log("Pool ID: " + currAttackInfo[currWave]);
            Debug.Log("Total enemy: " + currAttackInfo[currWave + 1]);
            Debug.Log("Spawn gap: " + currAttackInfo[currWave + 2]);
            Debug.Log("Start delay: " + currAttackInfo[currWave + 3]);
            Debug.Log("End delay: " + currAttackInfo[currWave + 4] + "\n");

            //Set ID
            poolId = currAttackInfo[currWave];

            //Set start time delay
            yield return new WaitForSeconds(currAttackInfo[currWave + 3]);

            //Start Spawn
            enemyPool[poolId].StartSpawn(currAttackInfo[currWave+1], currAttackInfo[currWave+2], pathNum);

            //Set spawn time delay + end time delay
            yield return new WaitForSeconds(currAttackInfo[currWave + 4] + (currAttackInfo[currWave + 1]) * (currAttackInfo[currWave + 2]));

            currWave += 5;
        }

        waveButton.SetActive(true);
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

    void ReadCurrAttackInfo(){
        waveNum = Convert.ToInt32(lines[currLine]);
        currLine++;
        currWave = 0;
        currAttackInfo.Clear();
        
        for (int i = 0; i < waveNum; i++){
            foreach (string num in lines[currLine+i].Split('\t'))
            {
                //Debug.Log(num);
                currAttackInfo.Add(Convert.ToInt32(num));
            };
        }
        currLine += waveNum;
    }
}

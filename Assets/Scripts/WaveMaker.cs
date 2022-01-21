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

    [SerializeField] int[] currWaveInfo;

    [SerializeField] int wave;
    TextAsset textAssetNames;
    string[] lines;

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartWave(){
        
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

        lines = textAssetNames.text.Split(new string[] { "\n" }, StringSplitOptions.None);
    }

    void ReadCurrWaveInfo(){
        int i = 0;

        foreach (string num in lines[wave].Split(char.Parse(" "))) {
            currWaveInfo[i] = Convert.ToInt32(num);
            i++;
        };
    }
}

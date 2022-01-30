using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] int hitPoints = 25;
    [SerializeField] int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = hitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit(){
        currentHitPoints--;

        if(currentHitPoints <= 0){
            gameObject.SetActive(false);
        }
    }
}

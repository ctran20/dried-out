using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    int currentHitPoints = 0;


    // Start is called before the first frame update
    void Start()
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
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Start is called before the first frame update
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
            enemy.RewardGold();
        }
    }
}

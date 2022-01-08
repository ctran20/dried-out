using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;

    [Tooltip("Add amount to hitpoints when enemies die.")]
    [SerializeField] int difficultyRamp = 2;
    
    int currentHitPoints = 0;

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
            hitPoints += 1;
            enemy.RewardGold();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;

    [Tooltip("Add amount to hitpoints when enemies die.")]
    [SerializeField] int difficultyRamp = 2;
    [SerializeField] GameObject armor;

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

        if(armor){
            armor.SetActive(true);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        int damage = other.GetComponent<ParticleSystemDamage>().GetDamage();
        ProcessHit(damage);
    }

    void ProcessHit(int damage){
        currentHitPoints -= damage;

        if(currentHitPoints <= 0){
            gameObject.SetActive(false);
            hitPoints += 1;
            enemy.RewardGold();
        }
    }
}

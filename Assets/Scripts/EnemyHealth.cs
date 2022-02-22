using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] GameObject armor;

    int currentHitPoints = 0;
    bool damaging;
    bool poisoned;
    int poisonDamage;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        poisonDamage = 0;
        poisoned = false;
        damaging = false;
    }

    private void Update()
    {
        if (poisoned && !damaging)
        {
            StartCoroutine(Poison());
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = hitPoints;
        poisoned = false;
        damaging = false;

        if (armor){
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

    public void PoisonHit(int damage)
    {
        if(damage > 0){
            poisonDamage = damage;
            poisoned = true;
        }else{
            poisonDamage = 0;
            poisoned = false;
        }
    }

    IEnumerator Poison()
    {
        damaging = true;
        ProcessHit(poisonDamage);
        yield return new WaitForSeconds(1f);
        damaging = false;
    }
}

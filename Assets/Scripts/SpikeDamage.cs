using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] int damage;    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().PoisonHit(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<EnemyHealth>().PoisonHit(-1);
    }
}

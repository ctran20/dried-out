using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 25f;
    Transform target;
    bool targeting;

    private void Start()
    {
        targeting = false;
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = false;
    }

    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        EnemyCenter[] enemies = FindObjectsOfType<EnemyCenter>();
        if(enemies.Length > 0){
            foreach (EnemyCenter enemy in enemies)
            {
                float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

                if (targetDistance < range)
                {
                    target = enemy.transform;
                    Attack(true);
                    break;
                }else{
                    Attack(false);
                }
            }
        }else{
            Attack(false);
        }
    }

    private void AimWeapon()
    {
        if (targeting)
        {
            weapon.LookAt(target);
        }
    }

    void Attack(bool isActive){
        targeting = isActive;
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;

    private void Start()
    {
        //target = FindObjectOfType<EnemyMover>().gameObject.transform;
        target = GameObject.FindGameObjectWithTag("Center").transform;
    }

    private void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        weapon.LookAt(target);
    }
}

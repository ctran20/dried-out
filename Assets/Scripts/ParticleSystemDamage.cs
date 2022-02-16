using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDamage : MonoBehaviour
{
    [SerializeField] int particleDamage = 1;

    public int GetDamage()
    {
        return particleDamage;
    }
}

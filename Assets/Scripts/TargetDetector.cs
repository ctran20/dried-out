using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    GameObject[] targetsInRange;

    private void OnTriggerEnter(Collider other)
    {
        //ActiveTarget(other);
    }

    private void OnTriggerExit(Collider other)
    {
        //ActiveTarget(other target in range);
    }
}

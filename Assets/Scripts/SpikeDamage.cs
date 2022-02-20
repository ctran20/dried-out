using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    bool coolDown;
    bool entered;

    private void Start()
    {
        coolDown = false;
        entered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        entered = false;
    }

    private void Update()
    {
        if (!coolDown && entered)
        {
            //TakeDamage(5f);
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        coolDown = false;
        yield return new WaitForSeconds(0.5f);
        coolDown = true;
    }
}

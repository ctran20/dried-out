using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speedX = 0;
    [SerializeField] float speedY = 0;
    [SerializeField] float speedZ = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(speedX, speedY, speedZ) * Time.deltaTime);
    }
}

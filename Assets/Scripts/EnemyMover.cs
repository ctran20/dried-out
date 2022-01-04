using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath(){
        foreach(Waypoint waypoint in path){
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}

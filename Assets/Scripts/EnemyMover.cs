using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    Enemy enemy;
    string pathTag = "Path1";

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    public void SetPath(int pathN)
    {
        pathTag = "Path" + pathN;
    }

    void FindPath(){
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag(pathTag);

        foreach(Transform child in parent.transform){
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if(waypoint != null){
                path.Add(child.GetComponent<Waypoint>());
            }
        }
    }

    void ReturnToStart(){
        transform.position = path[0].transform.position;
    }

    void FinishPath(){
        //Attack Base
        enemy.DamageHealth();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath(){
        foreach(Waypoint waypoint in path){
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f){
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}

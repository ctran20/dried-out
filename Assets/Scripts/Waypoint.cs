using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerMenu;
    [SerializeField] Tower cannonPrefab;
    [SerializeField] Tower archerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable{get{return isPlaceable;}}

    private void OnMouseDown()
    {
        if(isPlaceable){
            towerMenu.SetActive(true);
        }
    }

    public void PlaceCannon(){
        bool isPlaced = cannonPrefab.CreateTower(cannonPrefab, transform.position);
        isPlaceable = !isPlaced;
    }

    public void PlaceArcher()
    {
        bool isPlaced = archerPrefab.CreateTower(archerPrefab, transform.position);
        isPlaceable = !isPlaced;
    }
}

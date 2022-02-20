using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerMenu;
    [SerializeField] Tower cannonPrefab;
    [SerializeField] Tower archerPrefab;
    [SerializeField] Tower wizardPrefab;
    [SerializeField] Tower spikePrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable{get{return isPlaceable;}}

    public void Reset()
    {
        isPlaceable = true;
    }

    private void OnMouseDown()
    {
        if(isPlaceable){
            towerMenu.SetActive(true);
        }
    }

    public void PlaceSpike()
    {
        bool isPlaced = spikePrefab.CreateTower(spikePrefab, transform);
        isPlaceable = !isPlaced;
    }

    public void PlaceCannon(){
        bool isPlaced = cannonPrefab.CreateTower(cannonPrefab, transform);
        isPlaceable = !isPlaced;
    }

    public void PlaceArcher()
    {
        bool isPlaced = archerPrefab.CreateTower(archerPrefab, transform);
        isPlaceable = !isPlaced;
    }

    public void PlaceWizard()
    {
        bool isPlaced = wizardPrefab.CreateTower(wizardPrefab, transform);
        isPlaceable = !isPlaced;
    }
}

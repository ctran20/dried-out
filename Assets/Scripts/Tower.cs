using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] int level;

    [SerializeField] GameObject lvl1;
    [SerializeField] GameObject lvl2;
    [SerializeField] GameObject lvl3;

    private void Start()
    {
        level = 1;
    }

    public void Recycle(){
        Bank bank = FindObjectOfType<Bank>();
        bank.Deposit(45);
        gameObject.GetComponentInParent<Waypoint>().Reset();
        Destroy(gameObject);
    }

    public void Upgrade(){
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return;
        }

        if (bank.CurrentBalance >= cost)
        {
            SwapTower();
            bank.Withdraw(cost);
        }
        else{
            //Alert insufficient balance
        }
    }

    void SwapTower(){
        switch(level){
            case 1:
                lvl1.SetActive(false);
                lvl2.SetActive(true);
                break;
            case 2:
                lvl2.SetActive(false);
                lvl3.SetActive(true);
                break;
            default:
                break;
        }
        level++;
    }

    public bool CreateTower(Tower tower, Transform tile){
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null){
            return false;
        }

        if(bank.CurrentBalance >= cost){
            GameObject towerGO = Instantiate(tower.gameObject, tile.position, Quaternion.identity);
            towerGO.transform.SetParent(tile);
            bank.Withdraw(cost);
            return true;
        }else{
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 22f);
    }
}

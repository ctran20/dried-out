using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;
    public int CurrentBalance{get{ return currentBalance; } }

    private void Start()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount){
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
}

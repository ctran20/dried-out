using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    [SerializeField] int startingHealth = 20;
    [SerializeField] int currentHealth;
    [SerializeField] TextMeshProUGUI displayHealth;
    public int CurrentBalance{ get { return currentBalance; } }
    public int CurrentHealth { get { return currentHealth; } }

    private void Start()
    {
        currentBalance = startingBalance;
        currentHealth = startingHealth;
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

    public void Heal(int amount)
    {
        currentHealth += Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void Damage()
    {
        currentHealth -= 1;
        UpdateDisplay();

        if(currentHealth < 1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
        displayHealth.text = "Health: " + currentHealth;
    }
}

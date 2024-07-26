using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] private int currentBalance;
    [SerializeField] private GoldBoard goldCurrent;
    public int CurrentBalance
    {
        get
        {
            return currentBalance;
        }
    }
    void Awake()
    {
        currentBalance = startingBalance;
        goldCurrent = FindObjectOfType<GoldBoard>();

    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        goldCurrent.UpdateGold(currentBalance);
    }
    void Start()
    {
        if (goldCurrent)
            goldCurrent.UpdateGold(currentBalance);
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        goldCurrent.UpdateGold(currentBalance);
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }
    public void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Debug.Log("Noob");
    }
}

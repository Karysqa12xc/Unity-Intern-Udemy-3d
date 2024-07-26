using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    int cost = 25;
    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank)
        {
            if (bank.CurrentBalance >= cost)
            {
                Instantiate(tower, position, Quaternion.identity);
                bank.Withdraw(cost);
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
}

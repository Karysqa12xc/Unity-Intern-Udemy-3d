using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI heathTxt;
    void Start()
    {
        heathTxt.text = hitPoints.ToString();
    }
    public void TakeDamage(float hits)
    {
        hitPoints -= hits;
        if (hitPoints < 0)
        {
            heathTxt.text = "0";
        }
        else
        {
            heathTxt.text = hitPoints.ToString();
        }
        if (hitPoints <= 0)
        {
            Time.timeScale = 0;
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
    public void IncreaseHealth(int health)
    {
        if (hitPoints >= 100)
        {
            hitPoints = 100;
        }
        else
        {
            hitPoints += health;
        }
        heathTxt.text = hitPoints.ToString();
    }
}

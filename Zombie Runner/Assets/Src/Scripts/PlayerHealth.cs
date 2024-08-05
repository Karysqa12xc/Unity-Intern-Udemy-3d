using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    public void TakeDamage(float hits)
    {
        hitPoints -= hits;
        if (hitPoints <= 0)
        {
            Time.timeScale = 0;
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}

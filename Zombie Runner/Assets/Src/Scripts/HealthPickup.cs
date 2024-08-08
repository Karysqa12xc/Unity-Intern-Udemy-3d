using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    int health = 20;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerHealth>().IncreaseHealth(health);
            Destroy(gameObject);
        }
    }
}

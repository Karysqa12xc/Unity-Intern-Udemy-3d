using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player"){
            Debug.Log("You are finish the game");
        }
    }
}

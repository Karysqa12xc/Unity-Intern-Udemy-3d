using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.gameObject);
    }
    
}

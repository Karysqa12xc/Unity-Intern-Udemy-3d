using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    private bool _isDeath = false;
    public bool IsDeath
    {
        get
        {
            return _isDeath;
        }
        private set
        {
            _isDeath = value;
        }
    }


    public void TakeDamage(float hits)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= hits;
        if (hitPoints <= 0)
        {
            Die();
            Destroy(gameObject, 1.5f);
        }
    }
    private void Die()
    {
        if(_isDeath) return;
        _isDeath = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth target;
    [SerializeField] float damage = 40f;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    public void OnDamageTaken()
    {
        Debug.Log("You Are attack");
    }
    public void AttackHitEvent()
    {
        if(!target) return;
        target.TakeDamage(damage);
        Debug.Log("Mot dam la nam");
    }

}

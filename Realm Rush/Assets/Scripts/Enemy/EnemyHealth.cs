using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    public int maxHitPoint = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    public int difficultyRamp = 1;
    public int currentHitPoint = 0;
    Enemy enemy;

    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    // Update is called once per frame
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoint--;
        if (currentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoint += difficultyRamp;
            enemy.RewardGold();
        }
    }
}

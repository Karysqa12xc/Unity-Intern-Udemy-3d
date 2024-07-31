using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        Debug.DrawRay(FPCamera.transform.position, FPCamera.transform.forward * 30, Color.red);
    }
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            // TODO: Add hit effect for visual players
            if (hit.collider)
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target)
                {
                    Debug.Log("Attack");
                    target.TakeDamage(damage);
                }
            }

        }
        else
        {
            return;
        }
    }
}

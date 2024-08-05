using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 1f;
    [SerializeField] Transform parent;
    [SerializeField] GameObject bulletVfx;
    [SerializeField] ParticleSystem rayFireVfx;
    [SerializeField] float minRandom = -20f;
    [SerializeField] float maxRandom = -10f;
    void Start()
    {
        parent = GameObject.FindWithTag("Spawn").transform;
        rayFireVfx = GameObject.Find("Ray").GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
            Recoil();
            HandlerBolt(true);
        }else{
            HandlerBolt(false);
        }
        Debug.DrawRay(FPCamera.transform.position, FPCamera.transform.forward * range, Color.red);
    }

    private void HandlerBolt(bool isFire)
    {
        transform.GetChild(0)
            .GetComponent<Animator>().SetBool("IsRecoil", isFire);   
    }

    private void Shoot()
    {
        PlayEffect();
        ProcessRayCast();
    }

    private void PlayEffect()
    {
        if (rayFireVfx)
        {
            rayFireVfx.Play();
        }
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            // TODO: Add hit effect for visual players
            if (hit.collider)
            {
                GameObject bvfx = Instantiate(bulletVfx, hit.point,
                       FPCamera.transform.rotation);
                bvfx.transform.parent = parent;

                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target)
                {
                    target.TakeDamage(damage);
                }
            }
        }
        else
        {
            return;
        }
    }

    public void Recoil()
    {
        float RandomX = Random.Range(minRandom, maxRandom);
        GameObject player = GameObject.FindWithTag("CinemachineTarget");
        Quaternion randomRotation = Quaternion.Euler(RandomX, 0, 0);
        player.transform.rotation *= randomRotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem.WebGL;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    ParticleSystem deathVFX;
    AudioSource deathAudio;
    public GameObject hitVFX;
    public GameObject parent;
    public ScoreBoard scoreBoard;
    public new Collider collider;
    public bool isDeath = false;
    public int hitPoints = 2;
    void Start()
    {
        
        scoreBoard = GameObject.FindWithTag("Score").GetComponent<ScoreBoard>();
        parent = GameObject.FindWithTag("SpawnPoint");
        deathVFX = GetComponentInChildren<ParticleSystem>();        
        deathAudio = GetComponentInChildren<AudioSource>();
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
        isDeath = false;
    }

    void OnParticleCollision(GameObject other)
    {
        // if (isDeath) return;
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        deathVFX.Play();
        isDeath = true;
        collider.enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        hitPoints--;
        if(hitPoints <= 0){
            deathAudio.Play();
            scoreBoard.IncreaseScore(1);    
        }
    }
}

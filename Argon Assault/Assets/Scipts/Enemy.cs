using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem.WebGL;
// TODO: Xử lý các sự kiện của Enemy
public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject deathVFX;
    public AudioSource deathAudio;
    public GameObject hitVFX;
    public GameObject parent;
    public ScoreBoard scoreBoard;
    public new Collider collider;
    public int hitPoints = 2;
    void Start()
    {
        
        scoreBoard = GameObject.FindWithTag("Score").GetComponent<ScoreBoard>();
        parent = GameObject.FindWithTag("SpawnPoint");
        deathAudio = parent.GetComponent<AudioSource>();
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        // if (isDeath) return;
        ProcessHit();
        if (hitPoints < 1)
        {
            deathAudio.Play();
            KillEnemy();
        }
    }

    private void KillEnemy()
    {        
        collider.enabled = false;
        GameObject dvfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        dvfx.transform.parent = parent.transform;
        Destroy(dvfx, 1f);  
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject hvfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hvfx.transform.parent = parent.transform;
        Destroy(hvfx, 1f);
        hitPoints--;
        if(hitPoints <= 0){
            
            scoreBoard.IncreaseScore(1);    
        }
    }
}

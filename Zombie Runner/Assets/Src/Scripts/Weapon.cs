using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShot = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] AudioSource shootSound;
    [SerializeField] AudioClip shootClip;
    [SerializeField] FlashLightSystem flashLightSystem;
    [SerializeField] float intensityLight = 1f;
    GameObject player;
    bool canShoot = true;
    void Start()
    {
        parent = GameObject.FindWithTag("Spawn").transform;
        player = GameObject.FindWithTag("CinemachineTarget");
        rayFireVfx = GameObject.Find("Ray").GetComponent<ParticleSystem>();
        shootSound = GetComponentInParent<AudioSource>();
    }
    void OnEnable()
    {
        canShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && ammoSlot.GetCurrentAmount(ammoType) > 0
            && canShoot)
        {
            StartCoroutine(Shoot());
            Recoil();
            HandlerBolt(true);
            shootSound.PlayOneShot(shootClip);
        }
        else
        {
            HandlerBolt(false);
        }
        DisplayAmmo();
        Debug.DrawRay(FPCamera.transform.position, FPCamera.transform.forward * range, Color.red);
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
    private void HandlerBolt(bool isFire)
    {
        transform.GetChild(0)
            .GetComponent<Animator>().SetBool("IsRecoil", isFire);
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        PlayEffect();
        ProcessRayCast();
        if (flashLightSystem.MyLight.intensity < 10)
        {
            flashLightSystem.RestoreLightIntensity(intensityLight);
        }
        ammoSlot.ReduceCurrentAmmo(ammoType);
        yield return new WaitForSeconds(timeBetweenShot);
        canShoot = true;
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
                if(hit.collider.CompareTag("Spawn"))
                {
                    FindObjectOfType<WarmUpStart>().spawnedObjects.Remove(hit.collider.gameObject);
                    Destroy(hit.collider.gameObject);
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
        Quaternion randomRotation = Quaternion.Euler(RandomX, 0, 0);
        player.transform.rotation *= randomRotation;
    }
}

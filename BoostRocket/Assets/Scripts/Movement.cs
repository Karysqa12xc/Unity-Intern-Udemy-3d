using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
// TODO: Di chuyển Rocket
public class Movement : MonoBehaviour
{
    private Rigidbody _rb;
    private AudioSource _audioSource;
    public AudioClip mainEngine;
    public float mainThrust = 10f;
    public float rotationThrust = 10f;
    public ParticleSystem mainEngineParticle;
    public ParticleSystem leftThrustParticle;
    public ParticleSystem rightThrustParticle;
    public float maxHeight = 26f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void UnlockMove()
    {
        if (transform.rotation.z == 0)
        {
            _rb.constraints = RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            _rb.constraints = RigidbodyConstraints.None |
           RigidbodyConstraints.FreezeRotation
           | RigidbodyConstraints.FreezePositionZ;
        }

    }

    private void StopRotating()
    {
        if (rightThrustParticle && leftThrustParticle)
        {
            rightThrustParticle.Stop();
            leftThrustParticle.Stop();
        }
    }

    private void RotateRight()
    {

        ApplyRotation(Vector3.back);

        if (!rightThrustParticle.isPlaying)
        {
            rightThrustParticle.Play();
        }
    }

    private void RotateLeft()
    {
        // UnlockMove();
        ApplyRotation(Vector3.forward);
        if (!leftThrustParticle.isPlaying)
        {
            leftThrustParticle.Play();
        }
        leftThrustParticle.Play();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            UnlockMove();
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        _audioSource.Stop();
        if (mainEngineParticle)
            mainEngineParticle.Stop();
    }

    private void StartThrusting()
    {
        // TODO: Add lực phụ thuộc vào hướng của vật thể
        Debug.Log(transform.position.y);
        if(transform.position.y <= maxHeight){
            _rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime, ForceMode.Force);
        }
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

    public void ApplyRotation(Vector3 direction)
    {
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
    }
}

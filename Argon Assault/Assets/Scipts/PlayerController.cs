using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship move up and down based player input")]
    public float controlSpeed;
    [Header("Screen position handle")]
    float horizontalThrow;
    float verticalThrow;
    public float xRange = 5f;
    public float yRange = 5f;
    public float positionPitchFactor = -2f;
    public float positionYawFactor = -2f;
    public float positionRollFactor = -2f;
    [Header("Laser Gun Array")]
    [Tooltip("Add all laser of player")]
    public GameObject[] Lasers;
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
    // TODO: Di chuyển vật thể theo chiều trái phải
    private void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        float xOffset = horizontalThrow * Time.deltaTime
        * controlSpeed;
        float rawXPos = transform.localPosition.x
        + xOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = verticalThrow * Time.deltaTime
        * controlSpeed;
        float rawYPos = transform.localPosition.y
       + yOffset;

        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new
        Vector3(
        clampedXPos,
        clampedYPos,
        transform.localPosition.z
        );
    }
    // TODO: Xoay vật thể
    public void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * positionRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    // TODO: Bắn đạn
    public void ProcessFiring()
    {
        
        if(Input.GetButton("Fire1")){
            SetLaserActive(true);
        }else{
            SetLaserActive(false);
        }
    }

    private void SetLaserActive(bool isActive)
    {
          
        foreach (GameObject laser in Lasers)
        { 
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
        
    }
}

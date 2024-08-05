using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] float zoomOut = 70f;
    [SerializeField] float zoomIn = 26f;
    void Start()
    {
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cinemachineCamera.m_Lens.FieldOfView = zoomIn;
        }else{
            cinemachineCamera.m_Lens.FieldOfView = zoomOut;
        }
    }
}

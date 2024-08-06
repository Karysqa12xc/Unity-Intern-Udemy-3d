using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    void Start()
    {
        gameOverCanvas.enabled = false;
    }
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        FindFirstObjectByType<WeaponSwitcher>().enabled = false;
        FindFirstObjectByType<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

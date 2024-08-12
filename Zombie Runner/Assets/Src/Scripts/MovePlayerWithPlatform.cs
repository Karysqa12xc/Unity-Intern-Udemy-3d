using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class MovePlayerWithPlatform : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    private Vector3 lastPlatformPosition;
    private bool isOnPlatform;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        PlayerFollowPlatform();
    }

    private MoveObstacle CheckPlatformUnderPlayer()
    {
        var ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        float maxDistance = (controller.height / 2f) + 0.01f;
        Debug.DrawRay(transform.position, Vector3.down * maxDistance, Color.red);
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            var platform = hit.collider.gameObject.GetComponentInParent<MoveObstacle>();
            if (platform != null)
            {
                return platform;
            }
        }
        return null;
    }
    public void PlayerFollowPlatform()
    {
        MoveObstacle platform = CheckPlatformUnderPlayer();
        if (platform != null)
        {
            if (!isOnPlatform)
            {
                lastPlatformPosition = platform.transform.position;
                isOnPlatform = true;
            }
            Vector3 platformMovement = platform.transform.position - lastPlatformPosition;
            Debug.Log(platformMovement);
            controller.Move(platformMovement);
            lastPlatformPosition = platform.transform.position;
        }else{
            isOnPlatform = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO: Quản lý va chạm vào player
public class ObjectHit : MonoBehaviour
{
    MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnCollisionEnter(Collision other)
    {
        /*
            * Vật thể va trúng player thì đổi tên 
            * và màu của vật thế
        */
        if (other.gameObject.tag == "Player")
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
    }
}

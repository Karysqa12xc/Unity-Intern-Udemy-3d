using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO: Quản lý va chạm vào player
public class ObjectHit : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField] bool isTouch = false;
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
        {
            
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            if(!isTouch){
                gameObject.transform.position += new Vector3(0, -0.1f, 0);
                isTouch = true;
            }
            gameObject.tag = "Hit";
        }
    }
}

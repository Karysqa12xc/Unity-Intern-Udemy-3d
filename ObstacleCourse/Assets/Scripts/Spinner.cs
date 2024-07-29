using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO: Xoay tròn vật thể
public class Spinner : MonoBehaviour
{
    [SerializeField] float 
    xAngle = 0, 
    yAngle = 0, 
    zAngle = 0;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}

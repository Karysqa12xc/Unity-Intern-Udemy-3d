using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlScale : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)){
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            transform.GetChild(0).GetChild(0).localScale = new Vector3(1f, 2f, 1f);
        }else{
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
        }
    }
}

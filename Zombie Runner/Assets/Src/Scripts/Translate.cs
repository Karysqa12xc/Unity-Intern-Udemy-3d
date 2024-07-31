using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class Translate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        foreach(Material mat in Resources.FindObjectsOfTypeAll<Material>())
        {
            if(mat.shader.name == "Universal Render Pipeline/Lit"){
                mat.shader = Shader.Find("Standard");
            }
        }
    }
}

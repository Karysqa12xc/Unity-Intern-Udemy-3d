using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
      
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitFeather();
            Debug.Log("Pushed escape");
        }  
    }
    public void QuitFeather()
    {
        Application.Quit();
    }
}

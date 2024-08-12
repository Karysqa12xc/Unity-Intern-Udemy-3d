using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMenu : MonoBehaviour
{
    [SerializeField] bool isToggle = false;
    void Update()
    {
        HandlerGameOverScreen();
    }
    public void HandlerGameOverScreen()
    {
        if(Input.GetKeyDown(KeyCode.P))
            isToggle = !isToggle;
        gameObject.SetActive(isToggle);
    }
}

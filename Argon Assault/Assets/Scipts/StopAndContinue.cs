using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAndContinue : MonoBehaviour
{
    [SerializeField] GameObject hideUI;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        hideUI.SetActive(false);
    }
}

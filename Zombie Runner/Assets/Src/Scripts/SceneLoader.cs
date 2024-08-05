using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;   
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;        
    }
    public void ExitScene()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
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
    public void NextScene(){
        int nextMap =  SceneManager.GetActiveScene().buildIndex + 1;
        if(nextMap != SceneManager.sceneCount){
            nextMap = 0;
        }
        SceneManager.LoadScene(nextMap);
    }
    public void LoadChooseScene(int index)
    {
        SceneManager.LoadScene(index);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}

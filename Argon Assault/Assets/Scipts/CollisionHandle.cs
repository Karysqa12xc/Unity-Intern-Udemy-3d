using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandle : MonoBehaviour
{
    public ParticleSystem explosion;
    void OnCollisionEnter(Collision other)
    {        
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<PlayerController>().enabled = false;
        if (explosion != null){
            explosion.Play();
        }
        yield return new WaitForSeconds(1f);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (currentScene == SceneManager.sceneCount)
        {
            nextScene = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}

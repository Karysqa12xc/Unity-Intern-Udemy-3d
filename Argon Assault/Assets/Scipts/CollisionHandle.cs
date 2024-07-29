using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// TODO: Xử lý sự kiện khi va chạm của player
public class CollisionHandle : MonoBehaviour
{
    public ParticleSystem explosion;
    void OnCollisionEnter(Collision other)
    {        
        if(other.gameObject.tag == "Finish"){
            Invoke("LoadNextScene", 1f);
        }
        else if(other.gameObject.tag != "Finish"){
            StartCoroutine(ReloadScene());
        }
    }
    // TODO: load lại màn chơi
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
    // TODO: chuyển màn nếu người chơi đi đến điểm cuối
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (currentScene == SceneManager.sceneCount)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    public float levelLoadDelay = 1f;
    public AudioClip success;
    public AudioClip crash;
    public AudioSource audioSource;
    public ParticleSystem successParticle;
    public ParticleSystem explosionParticle;
    bool isTransitioning = false;
    bool collisionDisable = false;
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        ResponseToDebugKeys();
    }

    private void ResponseToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisable) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("This thing is finish");
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("This thing is fuel");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    
    public void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        successParticle.Play();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    public void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        explosionParticle.Play();
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }
    // TODO: Chơi lại màn hiện tại
    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);

    }
    // TODO: Sang màn tiếp theo nếu chạm vào Finish
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}

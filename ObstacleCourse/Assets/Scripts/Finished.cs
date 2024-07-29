using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Finished : MonoBehaviour
{
    public TextMeshProUGUI UITextMeshPro;
    Scorer scorer;
    void Awake()
    {
        UITextMeshPro = GameObject.FindWithTag("UI").transform.GetChild(0)
            .GetComponent<TextMeshProUGUI>();
        scorer = FindObjectOfType<Scorer>();
    }   
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player"){
            UITextMeshPro.text = "You are finish the game\n" + scorer.Hits;
            Invoke("ReloadGame", 1f);
        }
    }
    void ReloadGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}

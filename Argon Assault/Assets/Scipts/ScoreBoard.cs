using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public Text scoreTxt;
    int score;
    void Start()
    {
        scoreTxt = FindObjectOfType<Text>();
        scoreTxt.text = "Start";
    }
    public void IncreaseScore(int amountIncrease)
    {
        score += amountIncrease;
        scoreTxt.text = score.ToString();    
    }
}

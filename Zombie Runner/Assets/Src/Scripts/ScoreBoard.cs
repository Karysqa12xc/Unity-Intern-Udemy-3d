using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    [Range(0, 100)]

    [SerializeField] int ScorePoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GetComponent<TextMeshProUGUI>();
        if (scoreTxt)
        {
            scoreTxt.text = "0/100";
        }
    }

    public void IncreaseScore(int score)
    {
        ScorePoint += score;
        scoreTxt.text = ScorePoint + "/100";
    }
}

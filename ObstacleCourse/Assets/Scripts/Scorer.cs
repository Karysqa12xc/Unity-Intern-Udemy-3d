using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// TODO: Tính điểm
public class Scorer : MonoBehaviour
{

    int hits = 0;
    public int Hits
    {
        private set
        {
            hits = value;
        }
        get
        {
            return hits;
        }
    }
    [SerializeField] TextMeshProUGUI score;
    void Start()
    {
        score = GameObject.FindWithTag("UI").transform
            .GetChild(1)
            .GetComponent<TextMeshProUGUI>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            hits++;
            score.text = hits + "";
        }
    }
}

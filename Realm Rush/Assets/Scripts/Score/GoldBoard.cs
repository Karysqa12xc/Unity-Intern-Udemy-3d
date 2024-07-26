using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class GoldBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Gold;
    // Start is called before the first frame update
    void Start()
    {
        Gold = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateGold(int gold)
    {
        if(Gold) Gold.text = "Gold: " + gold.ToString();
    }
}

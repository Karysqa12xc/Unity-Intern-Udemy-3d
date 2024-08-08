using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropper : MonoBehaviour
{   
    [SerializeField] GameObject[] items;
    private bool hasDropper = false;

    void Update()
    {
       DropItem(GetComponent<EnemyHealth>().IsDeath);
    }
    private void DropItem(bool isEnemyDie)
    {
        int randomItemIndex = Random.Range(0, items.Length);
        if(isEnemyDie && !hasDropper){
            Instantiate(items[randomItemIndex], transform.position, Quaternion.identity);
            hasDropper = true;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoorZombie : MonoBehaviour
{
    ScoreBoard scoreBoard;
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    // Update is called once per frame
    void Update()
    {
        if(CheckToDestroyDoor()){
            Destroy(gameObject);
        }
    }
    public bool CheckToDestroyDoor()
    {
        if(scoreBoard.ScoreCheck > 20){
            return true;
        }
        return false;
    }
}

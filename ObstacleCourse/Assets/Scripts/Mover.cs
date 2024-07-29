
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void PrintInstruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrows keys");
        Debug.Log("Don't hit the wall");
    }
    public void MovePlayer()
    {
        // TODO: Di chuyển vật thể theo position
        float horizontal  = Input.GetAxis("Horizontal");
        float vertical   = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        //? Tương tự transform.Translate()
        transform.position += movement * Time.deltaTime * speed;
    }
}

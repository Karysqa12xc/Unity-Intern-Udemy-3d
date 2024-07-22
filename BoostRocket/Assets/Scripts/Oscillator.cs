using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    public Vector3 movementVector;
    [SerializeField][Range(0.0f, 1.0f)] 
    float movementFactor;
    public float period = 10f;
    void Start()
    {
        startingPosition = transform.position;
    }
    void Update()
    {
        MovementFactor();
    }

    private void MovementFactor()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f;
        var offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}

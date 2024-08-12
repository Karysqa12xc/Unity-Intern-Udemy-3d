using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    Vector3 startingPosition;
    public Vector3 StartingPosition
    {
        get
        {
            return startingPosition;
        }
        private set
        {
            startingPosition = value;
        }
    }
    public Vector3 movementVector;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float movementFactor;
    public float period = 10f;
    public Vector3 CurrentOffset { get; private set; }
    public Vector3 CurrentPosition { get; private set; }
    public float RawSinWave {get; private set; }
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
        //* Kiểm tra chu kì quay của vật thể
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        // TODO: Trả ra sóng sin có giá trị trải từ -1 đến 1
        RawSinWave = Mathf.Sin(cycles * tau);
        // TODO: Chuyển giá trị sóng sin trải từ 0 đến 1 và gán
        movementFactor = (RawSinWave + 1f) / 2f;
        // TODO: Di chuyển
        CurrentOffset = movementVector * movementFactor;
        transform.position = startingPosition + CurrentOffset;
    }
}

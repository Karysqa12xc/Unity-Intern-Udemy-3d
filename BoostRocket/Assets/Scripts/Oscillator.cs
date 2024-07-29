using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO: Ứng dụng hàm lượng giác để di chuyển vật thể
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
        //* Kiểm tra chu kì quay của vật thể
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        // TODO: Trả ra sóng sin có giá trị trải từ -1 đến 1
        float rawSinWave = Mathf.Sin(cycles * tau);
        // TODO: Chuyển giá trị sóng sin trải từ 0 đến 1 và gán
        movementFactor = (rawSinWave + 1f) / 2f;
        // TODO: Di chuyển
        var offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}

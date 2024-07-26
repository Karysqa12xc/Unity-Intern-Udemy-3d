using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Tower tower;
    [SerializeField] private bool isPlaceable;
    public bool IsPlaceable
    {
        get { return isPlaceable; }
        set { isPlaceable = value; }
    }
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = tower.CreateTower(tower, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}

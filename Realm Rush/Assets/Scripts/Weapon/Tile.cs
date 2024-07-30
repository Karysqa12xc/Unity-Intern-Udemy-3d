using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.ComponentModel;

public class Tile : MonoBehaviour
{
    public Tower tower;
    [SerializeField] private bool isPlaceable;

    public bool IsPlaceable
    {
        get { return isPlaceable; }
        set { isPlaceable = value; }
    }
    GridManager gridManager;
    Pathfinder pathfinder;
    GameObject[] towerPrefabs;
    private float doubleClickTime = 0.2f;
    private float lastClickTime = 0f;
    Vector2Int coordinates = new Vector2Int();
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }
    void Start()
    {
        if (gridManager)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    void Update()
    {
        towerPrefabs = GameObject.FindGameObjectsWithTag("Tower");
    }
    void OnMouseDown()
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        if (timeSinceLastClick <= doubleClickTime)
        {
            for(int i = 0; i < towerPrefabs.Length; i++){
                if(transform.position == towerPrefabs[i].transform.position){
                    Destroy(towerPrefabs[i]);
                    gridManager.UnlockNode(coordinates);
                    pathfinder.NotifyReceivers();
                    tower.HandleDelete();
                    EnemyMover.IsStop = false;
                }
            }
        }
        else
        {
            if (gridManager.GetNode(coordinates) == null) return;
            if (gridManager.GetNode(coordinates).isWalkable
            && !pathfinder.WillBlockPath(coordinates))
            {
                if (transform.position != gridManager.GetPositionFromCoordinates(pathfinder.DestinationCoordinates)
                    && transform.position != gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates))
                {
                    bool isSuccessful = tower.CreateTower(tower, transform.position);
                    if (isSuccessful)
                    {
                        gridManager.BlockNode(coordinates);
                        pathfinder.NotifyReceivers();
                    }
                }
            }
        }
        lastClickTime = Time.time;
        

    }
}


using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Node> path = new List<Node>();

    [Range(0f, 5f)] public float speed = 1f;
    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;
    int minusCostPerTime = 15;
    public float timerToMinus = 0f;
    private static bool isStop = false;
    public static bool IsStop
    {
        get { return isStop; }
        set { isStop = value; }
    }
    Bank bank;
    // Start is called before the first frame update
    void Awake()
    {
        isStop = false;
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
        bank = FindObjectOfType<Bank>();
    }
    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
    }
    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();
        if (resetPath)
        {
            coordinates = pathfinder.StartCoordinates;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());

    }
    void Update()
    {
        MinusGoldFromLiveToDie(minusCostPerTime);
    }
    public void MinusGoldFromLiveToDie(int cost)
    {
        timerToMinus += Time.deltaTime;
        if (timerToMinus >= 1f)
        {
            if (isStop)
            {
                bank.Withdraw(cost);
            }
            timerToMinus = 0f;
        }
    }
    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }
    public void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    public IEnumerator FollowPath()
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
        if (path.Count != 1)
        {
            FinishPath();
        }
        else
        {
            isStop = true;
        }
    }

}


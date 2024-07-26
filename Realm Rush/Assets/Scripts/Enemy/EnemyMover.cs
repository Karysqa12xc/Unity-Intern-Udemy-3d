using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [Range(0f, 5f)] public float speed = 1f;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    void FindPath()
    {
        path.Clear();
        GameObject wayPoints = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in wayPoints.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            if (wayPoint != null)
            {
                path.Add(wayPoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    public void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    public IEnumerator FollowPath()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}

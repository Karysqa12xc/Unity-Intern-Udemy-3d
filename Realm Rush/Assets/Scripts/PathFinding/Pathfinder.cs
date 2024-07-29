using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
// TODO: Triển khai thuật toán BFS
public class Pathfinder : MonoBehaviour
{
    //Điểm xuất phát và điểm đích
    [SerializeField] Vector2Int startCoordinates;
    public Vector2Int StartCoordinates { get { return startCoordinates; } }
    [SerializeField] Vector2Int destinationCoordinates;
    public Vector2Int DestinationCoordinates
    {
        get
        {
            return destinationCoordinates;
        }
    }
    //Các node lưu trữ các điểm
    Node startNode;
    Node destinationNode;
    Node currentSearchNode;
    //Queue dùng để lưu trữ các vị trí cần duyệt trên Map
    Queue<Node> frontier = new Queue<Node>();
    // Dictionary để check giá trị được phép cho vào Queue
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    // Các hướng cần duyệt
    Vector2Int[] directions =
        { Vector2Int.up, Vector2Int.left, Vector2Int.down, Vector2Int.right };
    // Map    
    GridManager gridManager;
    // Map instance
    Dictionary<Vector2Int, Node> grids = new Dictionary<Vector2Int, Node>();
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager)
        {
            grids = gridManager.Grid;
            startNode = grids[startCoordinates];
            destinationNode = grids[destinationCoordinates];

        }

    }
    // Start is called before the first frame update
    void Start()
    {

        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        return GetNewPath(startCoordinates);
    }
    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        gridManager.ResetNodes();
        BreadthFirstSearch(coordinates);
        return BuildPath();
    }

    void ExploredNeighbors()
    {
        //Khởi tạo biến để lưu các toạ độ đã được duyệt
        List<Node> Neighbors = new List<Node>();
        for (int i = 0; i < directions.Length; i++)
        {
            //Duyệt các điểm lân cận theo các hướng
            Vector2Int neighborCoords = currentSearchNode.coordinates + directions[i];
            //Check xem điểm lân cận có tồn tại trong map hay không?
            if (grids.ContainsKey(neighborCoords))
            {
                //Thêm toạ độ đã thoả mãn
                Neighbors.Add(grids[neighborCoords]);
            }
        }
        //Duyệt các toạ độ trong các toạ độ đã được duyệt
        foreach (Node neighbor in Neighbors)
        {
            //Check xem toạ độ đó có thoả mãn để đưa vào Queue không
            if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                neighbor.connectTo = currentSearchNode;
                //Thêm vào các giá trị dã được check
                reached.Add(neighbor.coordinates, neighbor);
                //Thêm mới toạ độ cần duyệt
                frontier.Enqueue(neighbor);
            }
        }
    }
    void BreadthFirstSearch(Vector2Int coordinates)
    {
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;
        frontier.Clear();
        reached.Clear();
        //Flag điều kiện dừng
        bool isRunning = true;
        //Thêm dữ liệu đầu tiên vao queue
        frontier.Enqueue(grids[coordinates]);
        //Khởi tạo tạo độ đầu tiên đã được check
        reached.Add(coordinates, startNode);

        while (frontier.Count > 0 && isRunning)
        {
            // Lấy toạ độ vừa được thêm vào
            currentSearchNode = frontier.Dequeue();
            // Chuyển vị trí của toạ độ đó thành màu vàng
            currentSearchNode.isExplored = true;
            ExploredNeighbors();
            //Điều kiện đừng
            if (currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }
    }
    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;
        path.Add(currentNode);
        currentNode.isPath = true;
        while (currentNode.connectTo != null)
        {
            currentNode = currentNode.connectTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }
        path.Reverse();
        return path;
    }
    public bool WillBlockPath(Vector2Int coordinates)
    {
        if (grids.ContainsKey(coordinates))
        {
            bool previousState = grids[coordinates].isWalkable;
            List<Node> newPath = GetNewPath();
            grids[coordinates].isWalkable = previousState;
            if (newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }
        return false;
    }
    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", false, SendMessageOptions.DontRequireReceiver);
    }
}


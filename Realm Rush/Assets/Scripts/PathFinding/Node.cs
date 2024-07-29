using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO: Nơi lưu trữ dữ liệu toạ độ
[System.Serializable]
public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable, isExplored, isPath;
    public Node connectTo;
    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
}

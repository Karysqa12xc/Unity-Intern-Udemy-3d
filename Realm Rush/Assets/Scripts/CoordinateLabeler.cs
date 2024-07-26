using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    Color defaultColor = Color.white;
    Color blockedColor = Color.gray;
    [SerializeField]
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        wayPoint = GetComponentInParent<WayPoint>();
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabel();
    }
    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
    void SetLabelColor()
    {
        if (wayPoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x}, {coordinates.y}";
    }
    public void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}

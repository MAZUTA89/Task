using Map;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[RequireComponent(typeof(MapSettings))]
public class CameraVisability : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [ColorUsage(true)]
    [SerializeField] private Color _viewPointColor;
    [ColorUsage(true)]
    [SerializeField] private Color _invisiblePointColor;
    [SerializeField] bool _isDrawVisiblePoints;
    List<Vector3> _points;

    MapSettings _mapSettings;

    List<Vector3> _visiblePoints;
    List<Vector3> _invisiblePoints;

    private void Start()
    {
        _mapSettings = GetComponent<MapSettings>();
        _points = new List<Vector3>();
        _points = _mapSettings.GetPoints();
        
    }
    public void Update()
    {
    }
    public List<Vector3> GetVisiblePoints()
    {
        List<Vector3> points = new List<Vector3>();

        foreach (var point in _points)
        {
            if(IsPointVisible(point))
            {
                points.Add(point);
            }
        }
        return points;
    }

    public List<Vector3> GetInvisiblePoints()
    {
        List<Vector3> points = new List<Vector3>();

        foreach (var point in _points)
        {
            if (!IsPointVisible(point))
            {
                points.Add(point);
            }
        }
        return points;
    }

    private void OnDrawGizmos()
    {
        if (_isDrawVisiblePoints == false)
            return;

        if(_playerCamera != null && _points != null)
        {
            
            foreach(var point in _points)
            {
                if(IsPointVisible(point))
                {
                    Gizmos.color = _viewPointColor;
                    Gizmos.DrawCube(point, new Vector3(0.2f, 0.2f, 0.2f));
                }
                else
                {
                    Gizmos.color = _invisiblePointColor;
                    Gizmos.DrawCube(point, new Vector3(0.2f, 0.2f, 0.2f));
                }
            }
        }
    }

    public bool IsPointVisible(Vector3 position)
    {
        Vector3 viewPoint = _playerCamera.WorldToViewportPoint(position);
        return viewPoint.x > 0 && viewPoint.x < 1 && 
            viewPoint.y > 0 && viewPoint.y < 1 &&
            viewPoint.z > 0;
    }
}

using GameSO;
using Map;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(MapSettings))]
public class DangerZoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _speedZoneTemplate;
    [SerializeField] private DangerZoneSO _speedZoneSO;
    [SerializeField] private GameObject _deathZoneTemplate;
    [SerializeField] private DangerZoneSO _deathZoneSO;

    Transform _playerTransform;
    List<ZonePoint> _occupiedPoints;
    MapSettings _mapSettings;
    public void Initialize(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _occupiedPoints = new List<ZonePoint>();
        _mapSettings = GetComponent<MapSettings>();

        SetUpZones();
    }

    public class ZonePoint
    {
        public Vector3 Point;
        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (value < 0)
                {
                    _radius = 0;
                }
                else
                    _radius = value;
            }
        }

        float _radius;
    }

    void SetUpZones()
    {
        ZonePoint zonePoint = new ZonePoint()
        {
            Point = _playerTransform.position,
            Radius = _speedZoneSO.Radius
        };

        _occupiedPoints.Add(zonePoint);

        var points = _mapSettings.GetPoints();
        SetZones(points, _occupiedPoints,
            _speedZoneSO, _speedZoneTemplate);

        SetZones(points, _occupiedPoints,
            _deathZoneSO, _deathZoneTemplate);
    }
    void SetZones(List<Vector3> candidatePoints,
        List<ZonePoint> occupiedPoints, DangerZoneSO zoneSO,
        GameObject template)
    {

        for (int i = 0; i < zoneSO.ZonesAmount; i++)
        {
            var pointsOutsideOfOccupiedPoints =
            SearchForPointsToSetZone(candidatePoints, occupiedPoints);

            var pointsToSetZone = SearchForPointsToAccomodateZoneWithRadius
                (pointsOutsideOfOccupiedPoints, occupiedPoints, zoneSO.Radius);

            var randomIndex = Random.Range(0, pointsToSetZone.Count - 1);

            var zonePoint = new ZonePoint()
            {
                Point = pointsToSetZone[randomIndex],
                Radius = zoneSO.Radius
            };

            Instantiate(template, zonePoint.Point, Quaternion.identity, null);

            occupiedPoints.Add(zonePoint);
        }
    }

    List<Vector3> SearchForPointsToSetZone(List<Vector3> points,
        List<ZonePoint> zonePoints)
    {
        List<Vector3> pointsToLookZone = new List<Vector3>();

        for (int i = 0; i < points.Count; i++)
        {
            var point = points[i];
            bool isFree = false;
            for (int j = 0; j < zonePoints.Count; j++)
            {
                var occupied = zonePoints[j];
                if (IsPointInZone(point, occupied.Point, occupied.Radius))
                {
                    isFree = false;
                    break;
                }
                else
                {
                    isFree = true;
                }
            }

            if (isFree)
            {
                pointsToLookZone.Add(point);
            }
        }

        return pointsToLookZone;
    }

    List<Vector3> SearchForPointsToAccomodateZoneWithRadius(List<Vector3> points, 
        List<ZonePoint> zonePoints, float radius)
    {
        List<Vector3> pointsToSetZone = new List<Vector3>();

        for (int i = 0; i < points.Count; i++)
        {
            var point = points[i];

            bool isAccomodate = false;

            for (int j = 0;j < zonePoints.Count; j++)
            {
                var zonePoint = zonePoints[j];

                if(!IsPointAccomodateZone(point, zonePoint, radius))
                {
                    isAccomodate = false;
                    break;
                }
                else
                {
                    isAccomodate = true;
                }
            }

            if(isAccomodate)
            {
                pointsToSetZone.Add(point);
            }
        }

        return pointsToSetZone;
    }
    /// true, если находится, false, если нет
    /// </summary>
    /// <param name="point"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    bool IsPointInZone(Vector3 freePoint,
        Vector3 occupiedPoint, float radius)
    {
        Vector2 free = new Vector2(freePoint.x, freePoint.z);
        Vector2 ocuupied = new Vector2(occupiedPoint.x, occupiedPoint.z);

        return Vector2.Distance(free, ocuupied) <= radius;
    }
    /// <summary>
    /// true, если окружности не пересекаются.
    /// false, если пересекаются
    /// </summary>
    /// <param name="freePoint"></param>
    /// <param name="zonePoint"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    bool IsPointAccomodateZone(Vector3 freePoint,
        ZonePoint zonePoint, float radius)
    {
        Vector2 free = new Vector2(freePoint.x, freePoint.z);
        Vector2 zone = new Vector2(zonePoint.Point.x, zonePoint.Point.z);
        return Vector2.Distance(free, zone) >= zonePoint.Radius + radius;
    }
}

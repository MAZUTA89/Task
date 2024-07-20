using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class MapSettings : MonoBehaviour
    {
        [Header("Map:")]
        public bool IsDraw;
        [SerializeField] private Transform _formPoint;
        [Range(1f, 999f)]
        [SerializeField] private float _mapWidth;
        [Range(1f, 999f)]
        [SerializeField] private float _mapHeight;
        [ColorUsage(true)]
        [SerializeField] Color _linesColor;
        [Header("Points:")]
        [Range(0.5f, 10f)]
        [SerializeField] private float _boundsPointsRadius;
        [Range(0.2f, 1f)]
        [SerializeField] private float _step;
        [ColorUsage(true)]
        [SerializeField] Color _startColor;
        [ColorUsage(true)]
        [SerializeField] Color _endColor;
        [ColorUsage(true)]
        [SerializeField] Color _stepColor;

        public Vector3 StartPoint { get; private set; }
        public Vector3 EndPoint { get; private set; }

        float _minX, _maxX, _maxZ, _minZ, _y;
        List<Vector3> _stepPoints;
        private void OnValidate()
        {
           InitializeData();
            _stepPoints = GetStepPoints(StartPoint, EndPoint, _step);
            Debug.Log(_stepPoints.Count);
        }
        private void OnDrawGizmosSelected()
        {
            if (_formPoint == null)
                return;
           
            InitializeData();

            if (IsDraw)
            {
                DrawLines();
                DrawCirclesSE();
                DrawCirclesSteps();
            }
        }

        void DrawLines()
        {
            Debug.DrawLine(new Vector3(_minX, _y, _minZ), new Vector3(_maxX, _y, _minZ),
               _linesColor);
            Debug.DrawLine(new Vector3(_maxX, _y, _minZ), new Vector3(_maxX, _y, _maxZ),
                _linesColor);
            Debug.DrawLine(new Vector3(_maxX, _y, _maxZ), new Vector3(_minX, _y, _maxZ),
                _linesColor);
            Debug.DrawLine(new Vector3(_minX, _y, _maxZ), new Vector3(_minX, _y, _minZ),
                _linesColor);
        }
        void DrawCirclesSE()
        {
            Gizmos.color = _startColor;
            Gizmos.DrawSphere(StartPoint, _boundsPointsRadius / 2);
            Gizmos.color = _endColor;
            Gizmos.DrawSphere(EndPoint, _boundsPointsRadius / 2);
        }
        void DrawCirclesSteps()
        {
            Gizmos.color = _stepColor;

            foreach (var point in _stepPoints)
            {
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
        List<Vector3> GetStepPoints(Vector3 start, Vector3 end, float step)
        {
            var stepPoints = new List<Vector3>();
            for (float x = start.x; x > end.x; x -= step)
            {
                for (float z = start.z; z < end.z; z += step)
                {
                    stepPoints.Add(new Vector3(x, start.y, z));
                }
            }
            return stepPoints;
        }
        void InitializeData()
        {
            _minX = _formPoint.position.x - _mapWidth / 2;
            _maxX = _formPoint.position.x + _mapWidth / 2;
            _maxZ = _formPoint.position.z + _mapHeight / 2;
            _minZ = _formPoint.position.z - _mapHeight / 2;
            _y = _formPoint.position.y;

            StartPoint = new Vector3(_maxX, _y, _minZ);
            EndPoint = new Vector3(_minX, _y, _maxZ);
        }
        public List<Vector3> GetPoints()
        {
            OnValidate();
            return _stepPoints;
        }
    }
}
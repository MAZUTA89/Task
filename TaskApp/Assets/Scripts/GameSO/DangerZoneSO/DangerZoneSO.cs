using System;
using UnityEngine;

namespace GameSO
{
    [CreateAssetMenu(fileName = "DZ", menuName = "SO/DangerZone")]
    public class DangerZoneSO : ScriptableObject
    {
        [Range(1, 5)]
        public int ZonesAmount = 3;
        [Range(0.5f, 5f)]
        public float Radius = 3;
    }
}

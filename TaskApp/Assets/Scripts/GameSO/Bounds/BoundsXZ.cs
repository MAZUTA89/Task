using System;
using UnityEngine;

namespace GameSO
{
    [CreateAssetMenu(fileName = "BoundsXZ", menuName = "SO/BoundsXZ")]
    public class BoundsXZ : ScriptableObject
    {
        public float minX, maxX, minZ, maxZ;
    }
}

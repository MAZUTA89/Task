using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameSO
{
    [CreateAssetMenu(fileName = "Boost", menuName ="SO/Boost")]
    public class BoostSO : ScriptableObject
    {
        [Range(0, 10f)]
        public float ActiveTime;
    }
}

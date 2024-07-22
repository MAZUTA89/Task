using System;
using UnityEngine;

namespace GameSO
{
    [CreateAssetMenu(fileName = "Boost", menuName = "SO/SpeedBoost")]
    public class SpeedBoostSO : BoostSO
    {
        [Range(1f, 5f)]
        public float SpeedRatio;
    }
}

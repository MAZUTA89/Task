using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameSO
{
    [CreateAssetMenu(fileName ="EnemySO", menuName ="SO/EnemySO")]
    public class EnemySO : ScriptableObject
    {
        [Range(20, 200)]
        public int ScorePoints;
        [Range(1, 100)]
        public float SpawnChance;
        [Range(1, 6)]
        public float Speed;
        [Range(5, 60)]
        public int HP;
        [Range(0.2f, 5f)]
        public float CatchDistance;
    }
}

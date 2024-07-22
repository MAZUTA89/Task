using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameSO
{
    [CreateAssetMenu(fileName ="BoostSpawn", menuName ="SO/BoostSpawn")]
    public class BoostsSpawnSO : ScriptableObject
    {
        [Range(5, 100)]
        public float SpawnTime;
       
        [Range(1, 100)]
        public float BoostSpawnCnance;
    }
}

using UnityEngine;

namespace GameSO
{
    public class SpeedDangerZoneSO : DangerZoneSO
    {
        [Range(10, 70)]
        public float SpeedInfluenctInPrecents;
    }
}

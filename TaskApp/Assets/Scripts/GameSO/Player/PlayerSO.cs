using System;
using UnityEngine;

namespace GameSO
{
    [CreateAssetMenu(fileName ="PlayerSO", menuName ="SO/PlayerSO")]
    public class PlayerSO : ScriptableObject
    {
        [Range(3f, 20f)]
        public float MovementSpeed = 4f;
    }
}

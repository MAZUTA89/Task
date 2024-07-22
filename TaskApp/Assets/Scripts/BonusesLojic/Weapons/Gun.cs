using System;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Gun", menuName = "SO/Gun")]
    public class Gun : ScriptableObject, IGun
    {
        [SerializeField] private string _name;
        [Range(1, 10)]
        [SerializeField] private float _damage;
        [Range(1, 50)]
        [SerializeField] private float _range;
        [Range(0.1f, 10f)]
        [SerializeField] private float _speed;
        public string Name => _name;
        public float Damage => _damage;
        public float Range => _range;
        public float Speed => _speed;

        public virtual void Shoot()
        {
        }
    }
}

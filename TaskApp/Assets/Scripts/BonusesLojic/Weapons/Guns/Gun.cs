using System;
using UnityEngine;

namespace BonusLogic.Weapon
{
    [CreateAssetMenu(fileName = "Gun", menuName = "SO/Gun")]
    public class Gun : ScriptableObject, IGun
    {
        [SerializeField] private string _name;
        [Range(1, 10)]
        [SerializeField] private int _damage;
        [Range(1, 50)]
        [SerializeField] private float _range;
        [Range(0.1f, 10f)]
        [SerializeField] private float _speed;

        public string Name => _name;
        public int Damage => _damage;
        public float Range => _range;
        public float Speed => _speed;

        protected Transform _bulletPoint;
        public void Initialize(Transform bulletPoint)
        {
            _bulletPoint = bulletPoint;
        }

        public virtual void Shoot()
        {

        }
    }
}

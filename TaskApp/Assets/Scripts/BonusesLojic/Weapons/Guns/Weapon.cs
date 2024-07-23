using System;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform BulletSpawnPoint;
        [SerializeField] private Gun _gun;

        public IGun Gun => _gun;

        public Transform BulletTarget => BulletSpawnPoint;

        public virtual void Shoot()
        {

        }

        public GameObject GetObject()
        {
            return gameObject;
        }
    }
}

using System;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private Gun _gun;

        public IGun Gun => _gun;

        Vector3 _direction;

        public Transform BulletTarget => _bulletSpawnPoint;

        private void Update()
        {
            
        }
        public virtual void Shoot()
        {
            _direction = _bulletSpawnPoint.forward;

            Ray ray = new Ray(_bulletSpawnPoint.position, _direction);

            if(Physics.Raycast(ray, out RaycastHit hitInfo, _gun.Range))
            {
                Debug.Log(hitInfo.collider.name);
            }
        }

        public void OnSwitch()
        {

        }

        public GameObject GetObject()
        {
            return gameObject;
        }
    }
}

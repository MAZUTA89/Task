using EnemyLogic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    [RequireComponent(typeof(AudioSource))]
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private Gun _gun;

        public IGun Gun => _gun;

        protected Vector3 Direction;

        public Transform BulletTarget => _bulletSpawnPoint;

        AudioSource _audioSource;

        float _delay;

        bool _isDelayActive;
        float _currentDelayTime;

        private void Start()
        {
            _delay = 1 / _gun.Speed;
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(_isDelayActive)
            {
                _currentDelayTime += Time.deltaTime;

                if(_currentDelayTime >= _delay)
                {
                    _currentDelayTime = 0;
                    _isDelayActive = false;
                }
            }
        }
        public void Shoot()
        {
            if (_isDelayActive == true)
                return;
            Direction = _bulletSpawnPoint.forward;

            BulletsShoot();
            _audioSource.pitch = Random.Range(0.6f, 0.8f);
            _audioSource.Play();
            

            _isDelayActive = true;
        }

        protected virtual void BulletsShoot()
        {
            Ray ray = new Ray(_bulletSpawnPoint.position, Direction);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _gun.Range))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IEnemy enemy))
                {
                    enemy.TakeDamage(_gun.Damage);
                }
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

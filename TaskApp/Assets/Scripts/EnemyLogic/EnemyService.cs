using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyService : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemiesTemplates;

        public List<IEnemy> EnemiesTemplates => _enemies;

        List<IEnemy> _enemies;

        List<Enemy> _liveEnemies;

        EnemySpawner _enemySpawner;

        Transform _playerTransform;

        public void Initialize(Transform playerTransform,
            CameraVisability cameraVisability)
        {
            _enemies = new List<IEnemy>(_enemiesTemplates);

            _playerTransform = playerTransform;
            _enemySpawner = new EnemySpawner(_playerTransform,
                this, cameraVisability);

            _liveEnemies = new List<Enemy>();
        }

        private void Update()
        {
            _enemySpawner.Update(Time.deltaTime);
        }

        public void AddEnemy(Enemy enemy)
        {
            _liveEnemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _liveEnemies.Remove(enemy);
        }

        public List<Enemy> GetAliveEnemies()
        {
            return _liveEnemies;
        }
    }
}

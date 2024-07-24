using PlayerCode;
using Score;
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

        bool _isGameOver;

        Player _player;

        public void Initialize(Player player,
            CameraVisability cameraVisability,
            GameScore gameScore)
        {
            _enemies = new List<IEnemy>(_enemiesTemplates);

           _player = player;
            _enemySpawner = new EnemySpawner(_player,
                this, cameraVisability, gameScore);

            _liveEnemies = new List<Enemy>();
        }

        private void OnEnable()
        {
            GameEvents.OnEndGameEvent += OnEndGame;
        }
        private void OnDisable()
        {
            GameEvents.OnEndGameEvent -= OnEndGame;
        }

        private void Update()
        {
            if (_isGameOver)
                return;
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

        void OnEndGame()
        {
            _isGameOver = true;
            for (int i = 0; i < _liveEnemies.Count; i++)
            {
                Destroy(_liveEnemies[i].gameObject);
            }
        }
    }
}

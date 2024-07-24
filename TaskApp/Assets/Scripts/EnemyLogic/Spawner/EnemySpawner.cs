using UnityEngine;
using System.Collections.Generic;
using Score;
using PlayerCode;

namespace EnemyLogic
{
    public class EnemySpawner
    {
        const float c_startTime = 2f;
        const float c_updateSpawnTime = 10f;
        const float c_timeRatio = 0.1f;
        const float c_minSpawnTime = 0.5f;

        List<IEnemy> _templates;
        Player _player;
        CameraVisability _visability;
        EnemyService _enemyService;
        GameScore _gameScore;

        public float SpawnTimer
        {
            get
            {
                return _spawnTime;
            }
            private set
            {
                if(value < c_minSpawnTime)
                {
                    _spawnTime = c_minSpawnTime;
                }
                else
                    _spawnTime = value;
            }
        }
        float _spawnTime;
        float _updateTime;
        float _currentSpawnTime;


        public EnemySpawner(Player player, EnemyService enemyService,
            CameraVisability cameraVisability)
        {
            _visability = cameraVisability;
            _templates = enemyService.EnemiesTemplates;
            _player = player;
            _spawnTime = c_startTime;
            _enemyService = enemyService;
            _gameScore = new GameScore();
        }

        public void Update(float ticks)
        {
            _updateTime += ticks;
            _currentSpawnTime += ticks;

            if (_updateTime >= c_updateSpawnTime)
            {
                _updateTime = 0;

                SpawnTimer -= c_timeRatio;
            }

            if(_currentSpawnTime >= _spawnTime)
            {
                SpawnEnemy();
                _currentSpawnTime = 0;
            }
        }

        void SpawnEnemy()
        {
            float spawnWeights = 0;
            foreach (IEnemy enemy in _templates)
            {
                spawnWeights += enemy.SpawnChance;
            }

            float randomValue = Random.Range(0, spawnWeights);

            float currentValue = 0;

            foreach (Enemy enemy in _templates)
            {
                currentValue += enemy.SpawnChance;

                if(randomValue < currentValue)
                {
                    var point = GetRandomPoint();

                    var enemyObj = GameObject.Instantiate(enemy, point,
                        Quaternion.identity, null);

                    enemyObj.Initialize(_player,
                        _enemyService, _gameScore);

                    break;
                }
            }
            
        }

        Vector3 GetRandomPoint()
        {
            var pointsList = _visability.GetInvisiblePoints();

            int randomIndex = Random.Range(0, pointsList.Count);

            return pointsList[randomIndex];
        }


    }
}
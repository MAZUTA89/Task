using BonusLogic.Boosts;
using GameSO;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic
{
    public class BoostsSpawner
    {
        public float CurrentSpawnTimeField;
        BoostsSpawnSO _boostsSpawnSO;
        float _currentSpawnTime;
        IBoostFactory _speedBoostFactory;
        IBoostFactory _shieldBoostFactory;
        float _spawnWeight;
        CameraVisability _visability;

        Vector3 _randomPoint;
        
        public BoostsSpawner(BoostsSpawnSO boostsSpawnSO,
            IBoostFactory speedFactory, IBoostFactory shieldFactory,
            CameraVisability cameraVisability)
        {
            _boostsSpawnSO = boostsSpawnSO;
            _speedBoostFactory = speedFactory;
            _shieldBoostFactory = shieldFactory;
            _visability = cameraVisability;
        }

        public void Update(float ticks)
        {
            CurrentSpawnTimeField = _currentSpawnTime;
            _currentSpawnTime += ticks;

            if(_currentSpawnTime >= _boostsSpawnSO.SpawnTime)
            {
                _currentSpawnTime = 0;
                float randomValue = Random.Range(0, 101);

                if(randomValue <= _boostsSpawnSO.BoostSpawnCnance)
                {
                    float randomBoostValue = Random.Range(0, 101);

                    _randomPoint = GetRandomPoint();

                    if(randomBoostValue < 50)
                    {
                        SpawnSpeedBonus();
                    }
                    else
                    {
                        SpawnShieldBonus();
                    }

                }
            }
        }

        void SpawnSpeedBonus()
        {
            _speedBoostFactory.CreateBoostTrigger(_randomPoint);
        }

        void SpawnShieldBonus()
        {
            _shieldBoostFactory.CreateBoostTrigger(_randomPoint);
        }

        Vector3 GetRandomPoint()
        {
            List<Vector3> visiblePoints = _visability.GetVisiblePoints();

            int randomIndex = Random.Range(0, visiblePoints.Count);

            return visiblePoints[randomIndex];
        }
     }
}

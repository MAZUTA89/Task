using BonusLogic.Boosts;
using GameSO;
using PlayerCode;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic
{
    public class BonusesSpawnSystem : MonoBehaviour
    {
        [SerializeField] private BoostsSpawnSO _spawnSO;
        [SerializeField] private BoostTrigger _shieldTriggerTemplate;
        [SerializeField] private BoostTrigger _speedTriggerTemplate;
        CameraVisability _visability;
        BoostsSpawner _spawner;
        Player _player;
        public void Initialze(CameraVisability cameraVisability, Player player)
        {
            _visability = cameraVisability;
            _player = player;
            InitBoostsSpawner();
        }
        void InitBoostsSpawner()
        {
            IBoostFactory shieldFactory = 
                new BoostFactory(_shieldTriggerTemplate, _player);
            IBoostFactory speedFactory = 
                new BoostFactory(_speedTriggerTemplate, _player);
            _spawner = new BoostsSpawner(_spawnSO, speedFactory, 
                shieldFactory, _visability);
        }
        public void Update()
        {
            _spawner.Update(Time.deltaTime);
        }
    }
}

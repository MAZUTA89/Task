using BonusLogic.Boosts;
using BonusLogic.Weapon;
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
        [SerializeField] private List<GunTrigger> _gunTriggers;
        CameraVisability _visability;
        BoostsSpawner _boostsSpawner;
        WeaponSpawner _weaponSpawner;
        Player _player;
        WeaponService _weaponService;
        bool _isGameOver;
        public void Initialze(CameraVisability cameraVisability, Player player,
            WeaponService weaponService)
        {
            _visability = cameraVisability;
            _player = player;
            _weaponService = weaponService;
            InitBoostsSpawner();
            InitWeaponSpawner();
        }
        void InitBoostsSpawner()
        {
            IBoostFactory shieldFactory = 
                new BoostFactory(_shieldTriggerTemplate, _player);
            IBoostFactory speedFactory = 
                new BoostFactory(_speedTriggerTemplate, _player);
            _boostsSpawner = new BoostsSpawner(_spawnSO, speedFactory, 
                shieldFactory, _visability);
        }

        void InitWeaponSpawner()
        {
            WeaponTriggerFactoryProvider factoryProvider
                = new WeaponTriggerFactoryProvider();
            foreach (var gunTrigger in _gunTriggers)
            {
                IGunTriggerFactory gunTriggerFactory =
                    new GunTriggerFactory(gunTrigger, _weaponService,
                    _player);

                factoryProvider.Add(gunTriggerFactory);
            }

            _weaponSpawner = new WeaponSpawner(_weaponService, _player,
                _visability, factoryProvider);
        }

        private void OnEnable()
        {
            GameEvents.OnEndGameEvent += OnEndGame;
        }
        private void OnDisable()
        {
            GameEvents.OnEndGameEvent -= OnEndGame;
        }
        public void Update()
        {
            if (_isGameOver == false)
            {
                _boostsSpawner.Update(Time.deltaTime);
                _weaponSpawner.Update(Time.deltaTime);
            }
        }

        void OnEndGame()
        {
            _isGameOver = true;
        }
    }
}

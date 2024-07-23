using BonusLogic;
using BonusLogic.Weapon;
using BootLogic;
using DangerZoneCode;
using GameUI;
using GameInput;
using PlayerCode;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using EnemyLogic;


namespace GameSceneInitialization
{

    public class GameSceneInstaller : MonoBehaviour
    {
        Player _player;
        CameraFollow _cameraFollow;
        DangerZoneSpawner _zoneSpawner;
        GamePanel _gamePanel;

        CameraVisability _cameraVisability;

        BonusesSpawnSystem _bonusesSpawnSystem;

        WeaponService _weaponService;
        EnemyService _enemyService;
        private void Start()
        {
            _player = GetComponentInChildren<Player>();
            _cameraFollow = GetComponentInChildren<CameraFollow>();
            _zoneSpawner = GetComponentInChildren<DangerZoneSpawner>();
            _bonusesSpawnSystem = GetComponentInChildren<BonusesSpawnSystem>();
            _cameraVisability = GetComponentInChildren<CameraVisability>();

            _weaponService = GetComponentInChildren<WeaponService>();

            _enemyService = GetComponentInChildren<EnemyService>();

            var movementInput = GameCore.Instance().InputServiceProvider.
                Get(typeof(MovementInputService))
                as MovementInputService;

            _player.Initialize(movementInput, _weaponService);

            _cameraFollow.Initialize(_player.PlayerTransform);

            IDangerZoneFactory speedZoneFactory =
                new DangerZoneFactory(_zoneSpawner.SpeedZoneTemplate, _player);

            IDangerZoneFactory fatalZoneFactory =
                new DangerZoneFactory(_zoneSpawner.FatalZoneTemplate, _player);

            _zoneSpawner.Initialize(_player.PlayerTransform,
                speedZoneFactory, fatalZoneFactory);

            _gamePanel = GameCore.Instance().UI.GamePanel;

            _gamePanel.Activate();

            

            IShootInput shootInput = GameCore.Instance().
                InputServiceProvider.Get(typeof(ShootInputService))
                as ShootInputService;

            _weaponService.Initialize(_player, shootInput);

            _bonusesSpawnSystem.Initialze(_cameraVisability, _player, _weaponService);

            _enemyService.Initialize(_player.PlayerTransform, _cameraVisability);
        }
    }
}

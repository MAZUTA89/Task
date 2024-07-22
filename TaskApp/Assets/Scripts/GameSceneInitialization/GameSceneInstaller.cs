using BonusLogic;
using BootLogic;
using DangerZoneCode;
using GameUI;
using Input;
using PlayerCode;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        private void Start()
        {
            _player = GetComponentInChildren<Player>();
            _cameraFollow = GetComponentInChildren<CameraFollow>();
            _zoneSpawner = GetComponentInChildren<DangerZoneSpawner>();
            _bonusesSpawnSystem = GetComponentInChildren<BonusesSpawnSystem>();

            var movementInput = GameCore.Instance().InputServiceProvider.
                Get(typeof(MovementInputService))
                as MovementInputService;

            _player.Initialize(movementInput);

            _cameraFollow.Initialize(_player.PlayerTransform);

            IDangerZoneFactory speedZoneFactory =
                new DangerZoneFactory(_zoneSpawner.SpeedZoneTemplate, _player);

            IDangerZoneFactory fatalZoneFactory =
                new DangerZoneFactory(_zoneSpawner.FatalZoneTemplate, _player);

            _zoneSpawner.Initialize(_player.PlayerTransform,
                speedZoneFactory, fatalZoneFactory);

            _gamePanel = GameCore.Instance().UI.GamePanel;

            _gamePanel.Activate();

            _cameraVisability = GetComponentInChildren<CameraVisability>();

            _bonusesSpawnSystem.Initialze(_cameraVisability, _player);
        }
    }
}

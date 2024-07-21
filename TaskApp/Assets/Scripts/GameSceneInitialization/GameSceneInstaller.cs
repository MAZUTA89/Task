using BootLogic;
using DangerZoneCode;
using Input;
using PlayerCode;
using System;
using UnityEngine;


namespace GameSceneInitialization
{
    public class GameSceneInstaller : MonoBehaviour
    {
        Player _player;
        CameraFollow _cameraFollow;
        DangerZoneSpawner _zoneSpawner;
        private void Start()
        {
            _player = GetComponentInChildren<Player>();
            _cameraFollow = GetComponentInChildren<CameraFollow>();
            _zoneSpawner = GetComponentInChildren<DangerZoneSpawner>();


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
        }


    }
}

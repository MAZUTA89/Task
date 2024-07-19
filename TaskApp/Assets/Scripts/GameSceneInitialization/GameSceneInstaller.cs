using BootLogic;
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

        private void OnEnable()
        {
            _player = GetComponentInChildren<Player>();
            _cameraFollow = GetComponent<CameraFollow>();


            var movementInput = GameCore.Instance().InputServiceProvider.
                Get(typeof(MovementInputService))
                as MovementInputService;

            _player.Initialize(movementInput);


            _cameraFollow.Initialize(_player.PlayerTransform);

        }

        
    }
}

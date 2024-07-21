using PlayerCode;
using System;
using UnityEngine;

namespace DangerZoneCode
{
    public class SpeedDangerZone : DangerZone
    {
        [Range(10, 70)]
        [SerializeField] private float _speedInfluenctInPrecents;
        float _playerSpeed;
        private void Start()
        {
            _playerSpeed = (_speedInfluenctInPrecents *
                PlayerMovement.MovementSpeed) / 100;
        }
        protected override void OnPlayerEnter(PlayerMovement playerMovement)
        {
            playerMovement.ChangeSpeed(_playerSpeed);
        }

        protected override void OnPlayerExit(PlayerMovement playerMovement)
        {
            playerMovement.ResetSpeed();
        }

        protected override void OnPlayerStay(PlayerMovement playerMovement)
        {
        }
    }
}

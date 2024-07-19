using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCode
{
    internal class PlayerMovement
    {
        CharacterController _controller;
        Transform _playerTransform;
        Vector3 _direction;


        public PlayerMovement(CharacterController playerController)
        {
            _controller = playerController;
            _playerTransform = playerController.transform;
        }

        public void Update(float ticks,
            Vector3 mousePosition)
        {
            _direction = (mousePosition -
                _playerTransform.position).normalized;

            
        }
    }
}
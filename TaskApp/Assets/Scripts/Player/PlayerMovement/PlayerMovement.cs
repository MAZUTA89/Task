using Input;
using UnityEngine;

namespace PlayerCode
{
    internal class PlayerMovement
    {
        CharacterController _controller;
        Transform _playerTransform;
        Vector3 _direction;
        IMovementInput _movementInput;

        float _movementSpeed = 10f;

        public PlayerMovement(CharacterController playerController,
            IMovementInput movementInput)
        {
            _controller = playerController;
            _playerTransform = playerController.transform;
            _movementInput = movementInput;
        }

        public void Update(float ticks
            )
        {
            //_direction = (mousePosition -
            //    _playerTransform.position).normalized;

            Vector2 input = _movementInput.GetMovement();

            Vector3 movement = new Vector3(input.x, 
                0, input.y);

            movement = Vector3.ClampMagnitude(movement, _movementSpeed * ticks
                ) ;
            _controller.Move(movement);
        }
    }
}
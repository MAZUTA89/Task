using Input;
using UnityEngine;

namespace PlayerCode
{
    public class PlayerMovement
    {
        Rigidbody _rb;
        Transform _playerTransform;
        Vector3 _direction;
        IMovementInput _movementInput;

        float _movementSpeed = 4f;

        public Vector3 Movement { get; private set; }

        public PlayerMovement(Rigidbody rb,
            IMovementInput movementInput)
        {
            _rb = rb;
            _playerTransform = _rb.transform;
            _movementInput = movementInput;
        }

        public void Update(float ticks
            )
        {
            Vector2 input = _movementInput.GetMovement();
            Movement = new Vector3(input.x, 0, input.y);
        }

        public void FixedUpdate(float fixedTicks)
        {
            Vector3 newPos = Vector3.Lerp(_rb.position,
                _rb.position + Movement * _movementSpeed, fixedTicks);
            _rb.MovePosition(newPos);
        }
    }
}
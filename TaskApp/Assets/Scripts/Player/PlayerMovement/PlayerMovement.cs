using GameSO;
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
        public float MovementSpeed
        {
            get
            {
                return _movementSpeed;
            }
            set
            {
                if (value < 0.1f)
                {
                    _movementSpeed = 0.1f;
                }
                else
                {
                    _movementSpeed = value;
                }
            }
        }
        float _movementSpeed = 4f;
        float _defaultSpeed;
        public Vector3 Movement { get; private set; }

        public PlayerMovement(Rigidbody rb,
            IMovementInput movementInput,
            PlayerSO playerSO)
        {
            _rb = rb;
            _playerTransform = _rb.transform;
            _movementInput = movementInput;
            _movementSpeed = playerSO.MovementSpeed;
            _defaultSpeed = _movementSpeed;
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

        public void ChangeSpeed(float speed)
        {
            MovementSpeed = speed;
        }
        public void ResetSpeed()
        {
            MovementSpeed = _defaultSpeed;
        }
    }
}
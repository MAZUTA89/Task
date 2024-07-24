using GameSO;
using GameInput;
using UnityEngine;

namespace PlayerCode
{
    public class PlayerMovement
    {
        Rigidbody _rb;
        Transform _playerTransform;
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
        float _movementSpeed = 0.4f;
        float _defaultSpeed;
        public Vector3 Movement { get; private set; }

        Vector3 _newPosition;
        Vector3 _velocity;

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
            //_newPostition = Vector3.Lerp(_rb.position,
            //    _rb.position + Movement * _movementSpeed, fixedTicks);
            _newPosition = _rb.position + Movement * _movementSpeed * fixedTicks;
            _rb.MovePosition(_newPosition);
        }

        public void ChangeSpeed(float speed)
        {
            MovementSpeed = speed;
        }
        public void ResetSpeed()
        {
            MovementSpeed = _defaultSpeed;
        }
        public void Lock()
        {
            _movementInput.Disable();
        }
        public void Unlock() 
        {
            _movementInput.Enable();
        }
    }
}
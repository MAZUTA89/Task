using Input;
using UnityEngine;

namespace PlayerCode
{
    public class PlayerRotation
    {
        PlayerMovement _playerMovement;
        Transform _playerTransform;
        public float rotationSpeed = 720f;
        public PlayerRotation(PlayerMovement playerMovement,
            Transform playerTransform) 
        {
            _playerMovement = playerMovement;
            _playerTransform = playerTransform;
        }

        public void Update(float ticks)
        {
            
            Vector3 movement = _playerMovement.Movement;

            if (movement.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(_playerTransform.eulerAngles.y,
                    targetAngle, ref rotationSpeed, ticks);
                _playerTransform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }
    }
}

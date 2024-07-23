using BonusLogic.Weapon;
using GameInput;
using UnityEngine;

namespace PlayerCode
{
    public class PlayerRotation
    {
        PlayerMovement _playerMovement;
        Transform _playerTransform;
        private float _withOutWeaponRotationSpeed = 720f;
        private float _withWeaponRotationSpeed = 180f;
        WeaponService _weaponService;
        public PlayerRotation(PlayerMovement playerMovement,
            Transform playerTransform,
            WeaponService weaponService) 
        {
            _playerMovement = playerMovement;
            _playerTransform = playerTransform;
            _weaponService = weaponService;
        }

        public void Update(float ticks)
        {
            
            Vector3 movement = _playerMovement.Movement;

            if(_weaponService.HasWeapon)
            {
                Vector3 targetPoint = GetMousePosition();

                Vector3 targetDirection = targetPoint - _playerTransform.position;

                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

                _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation,
                    targetRotation, _withWeaponRotationSpeed * ticks);
            }
            else if (movement.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(_playerTransform.eulerAngles.y,
                    targetAngle, ref _withOutWeaponRotationSpeed, ticks);
                _playerTransform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }

        public Vector3 GetMousePosition()
        {
            Plane plane = new Plane(Vector3.up, _playerTransform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(plane.Raycast(ray, out float hitDist))
            {
                Vector3 targetPoint = ray.GetPoint(hitDist);

                return targetPoint;
                
            }
            else
            {
                return _playerTransform.forward;
            }
        }
    }
}

using GameSO;
using UnityEngine;

namespace PlayerCode
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _cameraObject;
        [SerializeField] private BoundsXZ _cameraBounds;
        private Transform _playerTarget;
        private Vector3 _targetPosition;
        private Vector3 _offset;
        float _followSpeed = 60f;
        Vector3 _velocity;
        public void Initialize(Transform playerTarget)
        {
            _playerTarget = playerTarget;
            _offset = playerTarget.position - _cameraObject.position;
        }

        public void Perform(float ticks)
        {
            _targetPosition = GetCameraFollowPosition(_offset,
                _playerTarget.position);

            float clampedX = Mathf.Clamp(_targetPosition.x,
                _cameraBounds.minX, _cameraBounds.maxX);
            float clampedZ = Mathf.Clamp(_targetPosition.z,
                _cameraBounds.minZ, _cameraBounds.maxZ);

            Vector3 clampedPosition = new Vector3(clampedX, _targetPosition.y,
                clampedZ);

            Vector3 newPos = Vector3.Lerp(_cameraObject.position
                , clampedPosition, ticks * _followSpeed);
            //Vector3 newPos = Vector3.SmoothDamp(_cameraObject.position
            //    , clampedPosition, ref _velocity,  0.3f);

            _cameraObject.position = newPos;
        }

        Vector3 GetCameraFollowPosition(Vector3 offset, Vector3 playerPosition)
        {
            return playerPosition - offset;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCode
{
    internal class CameraFollow
    {
        private Transform _playerTarget;
        private Transform _cameraObj;
        private Vector3 _targetPosition;
        private Vector3 _offset;
        private CameraBounds _bounds;
        public CameraFollow(Transform playerTarget, Transform cameraObject, CameraBounds bounds)
        {
            _playerTarget = playerTarget;
            _cameraObj = cameraObject;
            _offset = playerTarget.position - cameraObject.position;
            _bounds = bounds;
        }

        public void LateUpdate(float ticks)
        {
            _targetPosition = GetCameraFollowPosition(_offset,
                _playerTarget.position);

            // ќграничение позиции камеры границами карты
            float clampedX = Mathf.Clamp(_targetPosition.x, _bounds.minX, _bounds.maxX);
            float clampedZ = Mathf.Clamp(_targetPosition.z, _bounds.minZ, _bounds.maxZ);

            Vector3 clampedPosition = new Vector3(clampedX, _targetPosition.y,
                clampedZ);

            Vector3 newPos = Vector3.Lerp(_cameraObj.position
                ,clampedPosition, ticks);

            _cameraObj.position = newPos;
        }

        Vector3 GetCameraFollowPosition(Vector3 offset, Vector3 playerPosition)
        {
            return playerPosition - offset;
        }
    }
}
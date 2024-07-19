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
        public CameraFollow(Transform playerTarget, Transform cameraObject)
        {
            _playerTarget = playerTarget;
            _cameraObj = cameraObject;
            _offset = playerTarget.position - cameraObject.position;
        }

        public void Update(float ticks)
        {
            _targetPosition = GetCameraFollowPosition(_offset,
                _playerTarget.position);

            Vector3 newPos = Vector3.Lerp(_cameraObj.position
                ,_targetPosition, ticks);

            _cameraObj.position = newPos;
        }

        Vector3 GetCameraFollowPosition(Vector3 offset, Vector3 playerPosition)
        {
            return playerPosition - offset;
        }
    }
}
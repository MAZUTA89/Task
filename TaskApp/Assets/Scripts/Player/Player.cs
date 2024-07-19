using Unity.VisualScripting;
using UnityEngine;


namespace PlayerCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterController _playerController;
        [SerializeField] private Transform _cameraObjectTransform;

        private Transform _playerTransform;

        CameraFollow _cameraFollow;
        void Start()
        {
            _playerTransform = _playerController.transform;
            _cameraFollow = new CameraFollow(_playerTransform,
                _cameraObjectTransform);
        }

        public void Update()
        {
            _cameraFollow.Update(Time.deltaTime);
        }
    }
}
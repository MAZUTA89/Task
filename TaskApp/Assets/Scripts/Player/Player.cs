using BootLogic;
using Input;
using Unity.VisualScripting;
using UnityEngine;


namespace PlayerCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Transform _cameraObjectTransform;
        [SerializeField] private float _minX, _maxX, _minZ, _maxZ;

        private Transform _playerTransform;

        CameraFollow _cameraFollow;
        PlayerMovement _playerMovement;
        PlayerRotation _playerRotation;

        IMovementInput _movementInput;

        void Start()
        {
            _playerTransform = _rb.transform;

            _movementInput = GameCore.Instance().InputServiceProvider.
                Get(typeof(MovementInputService)) 
                as MovementInputService;

            var bounds = new CameraBounds()
            {
                maxX = _maxX,
                minZ = _minZ,
                maxZ = _maxZ,
                minX = _minX,
            };
            _cameraFollow = new CameraFollow(_playerTransform,
                _cameraObjectTransform, bounds);
            _playerMovement = new PlayerMovement(_rb,
                _movementInput);
            _playerRotation = new PlayerRotation(_playerMovement, _playerTransform);
        }

        public void Update()
        {
            _playerMovement.Update(Time.deltaTime);
            _playerRotation.Update(Time.deltaTime);
        }

        public void FixedUpdate()
        {
            _playerMovement.FixedUpdate(Time.fixedDeltaTime);
            _cameraFollow.LateUpdate(Time.fixedDeltaTime);
        }
        public void LateUpdate()
        {
            
        }
    }
}
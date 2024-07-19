using BootLogic;
using Input;
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
        PlayerMovement _playerMovement;

        IMovementInput _movementInput;

        void Start()
        {
            Debug.Log("Загружаю game scene!");
            _playerTransform = _playerController.transform;

            _movementInput = GameCore.Instance().InputServiceProvider.
                Get(typeof(MovementInputService)) 
                as MovementInputService;

            _cameraFollow = new CameraFollow(_playerTransform,
                _cameraObjectTransform);
            _playerMovement = new PlayerMovement(_playerController,
                _movementInput);
        }

        public void Update()
        {
            _cameraFollow.Update(Time.deltaTime);
            _playerMovement.Update(Time.deltaTime);
        }
    }
}
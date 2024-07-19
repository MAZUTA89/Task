using BootLogic;
using GameSO;
using Input;
using UnityEngine;


namespace PlayerCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Transform _cameraObjectTransform;
        [SerializeField] private PlayerSO _playerSO;
        

        public Transform PlayerTransform { get; private set; }

        PlayerMovement _playerMovement;
        public PlayerRotation PlayerRotation { get; private set; }

        IMovementInput _movementInput;

        public void Initialize(IMovementInput movementInput
            )
        {
            PlayerTransform = _rb.transform;

            _playerMovement = new PlayerMovement(_rb,
                _movementInput, _playerSO);

            PlayerRotation =
                new PlayerRotation(_playerMovement, PlayerTransform);
        }

        public void Update()
        {
            _playerMovement.Update(Time.deltaTime);
            PlayerRotation.Update(Time.deltaTime);
        }

        public void FixedUpdate()
        {
            _playerMovement.FixedUpdate(Time.fixedDeltaTime);
        }
        public void LateUpdate()
        {
            
        }
    }
}
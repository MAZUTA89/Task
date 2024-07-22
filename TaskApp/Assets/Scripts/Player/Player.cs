using BonusLogic;
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

        public string PlayerTag { get; private set; }
        public Transform PlayerTransform { get; private set; }

        public PlayerMovement PlayerMovement { get; private set; }
        public PlayerRotation PlayerRotation { get; private set; }

        public PlayerBoosts PlayerBoosts { get; private set; }

        IMovementInput _movementInput;

        public void Initialize(IMovementInput movementInput
            )
        {
            _movementInput = movementInput;

            _movementInput.Enable();

            PlayerTransform = _rb.transform;

            PlayerTag = PlayerTransform.tag; 

            PlayerMovement = new PlayerMovement(_rb,
                _movementInput, _playerSO);

            PlayerRotation =
                new PlayerRotation(PlayerMovement, PlayerTransform);


            var bonusesPanel = GameCore.Instance().UI.BonusesPanel;

            PlayerBoosts = new PlayerBoosts(bonusesPanel);
        }

        public void Update()
        {
            PlayerMovement.Update(Time.deltaTime);
            PlayerRotation.Update(Time.deltaTime);
            PlayerBoosts.Update(Time.deltaTime);
        }

        public void FixedUpdate()
        {
            PlayerMovement.FixedUpdate(Time.fixedDeltaTime);
        }
        public void LateUpdate()
        {
            
        }
    }
}
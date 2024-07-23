using GameUI;
using GameInput;
using SceneSwitch;
using UnityEngine;
namespace BootLogic
{
    [DefaultExecutionOrder(-50)]
    public class GameCore : PersistentSingleton<GameCore>
    {
        GameControls _inputActions;
        public InputServiceProvider InputServiceProvider { get; private set; }
        public UI UI { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            InitializeInputServices();

            UI = GetComponent<UI>();

            var sceneSwitcher = new SceneSwitcher();

            UI.Initialize(sceneSwitcher);
        }

        void InitializeInputServices()
        {
            _inputActions = new GameControls();
            InputServiceProvider = new InputServiceProvider();

            MovementInputService movementInputService =
                new MovementInputService(_inputActions);

            InputServiceProvider.RegisterService(movementInputService);

            ShootInputService shootInputService
                = new ShootInputService(_inputActions);

            InputServiceProvider.RegisterService(shootInputService);
        }
    }
}

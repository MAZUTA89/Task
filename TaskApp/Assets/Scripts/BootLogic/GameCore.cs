using Input;
using UnityEngine;
namespace BootLogic
{
    [DefaultExecutionOrder(-50)]
    public class GameCore : PersistentSingleton<GameCore>
    {
        GameControls _inputActions;
        public InputServiceProvider InputServiceProvider { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            Debug.Log("Загружаю Bootstrapp!");
            InitializeInputServices();
        }
        

        void InitializeInputServices()
        {
            _inputActions = new GameControls();
            InputServiceProvider = new InputServiceProvider();

            MovementInputService movementInputService =
                new MovementInputService(_inputActions);

            InputServiceProvider.RegisterService(movementInputService);
        }
    }
}

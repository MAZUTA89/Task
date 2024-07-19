using System;

namespace Input
{
    public abstract class InputService : IInputService
    {
        protected GameControls GameControls;
        public InputService(GameControls inputActions)
        {
            GameControls = inputActions;

            GameControls.Enable();
        }

        public abstract void Enable();
        public abstract void Disable();

        public void Dispose()
        {
            GameControls.Disable();
            GameControls.Dispose();
        }
    }
}

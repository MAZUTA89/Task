using System;
using System.Collections.Generic;

namespace GameInput
{
    public class ShootInputService : InputService, IShootInput
    {
        public ShootInputService(GameControls inputActions) : base(inputActions)
        {
        }

        public override void Disable()
        {
            GameControls.ShootMap.Disable();
        }

        public override void Enable()
        {
            GameControls.ShootMap.Enable();
        }

        public bool IsShoot()
        {
            return GameControls.ShootMap.Shoot.IsPressed();
        }
    }
}

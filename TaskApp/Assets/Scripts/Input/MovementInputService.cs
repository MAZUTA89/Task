
using UnityEngine;

namespace GameInput
{
    public class MovementInputService : InputService, IMovementInput
    {
        public MovementInputService(GameControls inputActions)
            : base(inputActions)
        {
        }

        public override void Disable()
        {
            GameControls.MovementMap.Disable();
        }

        public override void Enable()
        {
            GameControls.MovementMap.Enable();
        }

        public Vector2 GetMovement()
        {
            return GameControls.MovementMap.Movement.ReadValue<Vector2>();
        }
    }
}

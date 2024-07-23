using UnityEngine;

namespace GameInput
{
    public interface IMovementInput : IInputService
    {
        Vector2 GetMovement();
    }
}

using UnityEngine;

namespace Input
{
    public interface IMovementInput : IInputService
    {
        Vector2 GetMovement();
    }
}

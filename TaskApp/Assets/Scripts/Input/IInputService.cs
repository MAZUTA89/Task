using System;

namespace GameInput
{
    public interface IInputService: IDisposable
    {
        void Enable();
        void Disable();
    }
}
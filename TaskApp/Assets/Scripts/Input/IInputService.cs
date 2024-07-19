using System;

namespace Input
{
    public interface IInputService: IDisposable
    {
        void Enable();
        void Disable();
    }
}
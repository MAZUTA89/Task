using System;

namespace Weapons
{
    public interface IGun
    {
        string Name { get; }
        float Damage { get; }
        float Speed { get; }
        float Range { get; }
        void Shoot();
    }
}

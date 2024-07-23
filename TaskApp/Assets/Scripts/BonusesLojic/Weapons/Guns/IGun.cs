using System;

namespace BonusLogic.Weapon
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

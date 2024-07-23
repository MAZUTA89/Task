using System;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public interface IGun
    {
        string Name { get; }
        int Damage { get; }
        float Speed { get; }
        float Range { get; }
        void Shoot();
    }
}

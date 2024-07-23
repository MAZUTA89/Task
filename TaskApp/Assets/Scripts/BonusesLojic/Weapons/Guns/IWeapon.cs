using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public interface IWeapon
    {
        IGun Gun { get; }

        void Shoot();

        GameObject GetObject();
    }
}

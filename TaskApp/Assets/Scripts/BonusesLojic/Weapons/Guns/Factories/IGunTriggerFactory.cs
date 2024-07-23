using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public interface IGunTriggerFactory
    {
        string Name { get; }
        GunTrigger CreateGunTrigger(Vector3 position);
    }
}

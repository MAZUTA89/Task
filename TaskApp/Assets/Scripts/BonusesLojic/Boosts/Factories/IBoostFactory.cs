using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Boosts
{
    public interface IBoostFactory
    {
        BoostTrigger CreateBoostTrigger(Vector3 poition);
    }
}

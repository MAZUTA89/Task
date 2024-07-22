using System;
using UnityEngine.UI;

namespace BonusLogic.Boosts
{
    public interface IBoost
    {
        float ActionTime { get; set; }
        bool IsActive { get; set; }
        Image Image { get; set; }

        void Update(float ticks);
    }
}

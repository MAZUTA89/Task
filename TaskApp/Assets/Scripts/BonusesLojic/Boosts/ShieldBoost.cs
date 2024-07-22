using GameSO;
using PlayerCode;
using UnityEngine.UI;

namespace BonusLogic.Boosts
{
    public class ShieldBoost : Boost
    {

        public ShieldBoost(Player player, Image boostImage,
            BoostSO boostSO) : base(player, boostImage)
        {
            ActionTime = boostSO.ActiveTime;
        }

        public override void OnBoostActive()
        {
        }

        public override void OnBoostFinished()
        {
        }
    }
}

using GameSO;
using UnityEngine;

namespace BonusLogic.Boosts
{
    public class SpeedBoostTrigger : BoostTrigger
    {
        [SerializeField] private SpeedBoostSO _speedBonusSO;

        public override void ActivateBoost()
        {
            IBoost boost = new SpeedBoost(Player,
                PlayerBoosts.BonusesPanel.SpeedImage, _speedBonusSO);

            PlayerBoosts.Add(boost);
        }
    }
}

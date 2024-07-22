using GameSO;
using UnityEngine;

namespace BonusLogic.Boosts
{
    public class SpeedBoostTrigger : BoostTrigger
    {
        [SerializeField] private SpeedBoostSO _speedBonusSO;

        protected override void OnPlayerTriggered()
        {
            IBoost boost = new SpeedBoost(Player,
                PlayerBoosts.BonusesPanel.SpeedImage, _speedBonusSO);

            PlayerBoosts.Add(boost);
        }
    }
}

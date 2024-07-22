using BonusLogic;
using GameSO;
using System;
using UnityEngine;

namespace BonusLogic.Boosts
{
    public class ShieldBoostTrigger : BoostTrigger
    {
        [SerializeField] private BoostSO BonusSO;

        protected override void OnPlayerTriggered()
        {
            IBoost boost = new ShieldBoost(Player,
                PlayerBoosts.BonusesPanel.SheildImage,
                BonusSO);

            PlayerBoosts.Add(boost);
        }

    }
}

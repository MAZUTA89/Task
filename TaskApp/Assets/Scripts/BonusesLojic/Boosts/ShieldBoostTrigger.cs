using BonusLogic;
using GameSO;
using System;
using UnityEngine;

namespace BonusLogic.Boosts
{
    public class ShieldBoostTrigger : BoostTrigger
    {
        [SerializeField] private BoostSO BonusSO;

        public override void ActivateBoost()
        {
            IBoost boost = new ShieldBoost(Player,
                PlayerBoosts.BonusesPanel.SheildImage,
                BonusSO);

            PlayerBoosts.Add(boost);
        }

    }
}

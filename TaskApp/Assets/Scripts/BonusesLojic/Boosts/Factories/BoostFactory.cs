using PlayerCode;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Boosts
{
    public class BoostFactory : IBoostFactory
    {
        BoostTrigger _triggerTemplate;
        Player _player;
        public BoostFactory(BoostTrigger triggerTemplate, Player player)
        {
            _triggerTemplate = triggerTemplate;
            _player = player;
        }
        public BoostTrigger CreateBoostTrigger(Vector3 position)
        {
            var trigger = GameObject.Instantiate(_triggerTemplate, position, 
                Quaternion.identity, null);
            trigger.Initialize(_player);
            return trigger;
        }
    }
}

using BonusLogic.Boosts;
using GameUI;
using PlayerCode;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BonusLogic
{
    public class PlayerBoosts
    {
        List<IBoost> _boosts;
        
        
        public BonusesPanel BonusesPanel {  get; private set; }

        public PlayerBoosts(BonusesPanel bonusesPanel)
        {
            _boosts = new List<IBoost>();
            BonusesPanel = bonusesPanel;
        }
        public void Update(float ticks)
        {
            for (int i = 0; i < _boosts.Count; i++)
            {
                _boosts[i].Update(ticks);

                if (_boosts[i].IsActive == false)
                {
                    _boosts.RemoveAt(i);
                }
            }
        }

        public void Add(IBoost boost)
        {
            _boosts.Add(boost);
        }

        public bool IsBoostActive<T>() where T : IBoost
        {
            for (int i = 0; i < _boosts.Count; i++)
            {
                var boost = _boosts[i];
                if (boost.GetType() == typeof(T))
                    return true;
            }
            return false;
        }

    }
}

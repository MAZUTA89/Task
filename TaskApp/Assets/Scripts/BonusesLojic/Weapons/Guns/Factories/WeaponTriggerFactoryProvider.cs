using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class WeaponTriggerFactoryProvider
    {
        private Dictionary<string, IGunTriggerFactory> _gunFactories;

        public WeaponTriggerFactoryProvider()
        {
            _gunFactories = new Dictionary<string, IGunTriggerFactory>();
        }

        public void Add(IGunTriggerFactory gunTriggerFactory)
        {
            if(!_gunFactories.ContainsKey(gunTriggerFactory.Name))
            {
                _gunFactories[gunTriggerFactory.Name] = gunTriggerFactory;
            }
        }

        public IGunTriggerFactory Get(string name)
        {
            if(_gunFactories.ContainsKey(name))
            {
                return _gunFactories[name];
            }
            else
            {
                Debug.LogError($"{name} не найден!");
                return default;
            }
        }
    }
}

using PlayerCode;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class GunTriggerFactory : IGunTriggerFactory
    {
        string _name;
        GunTrigger _triggerTemplate;
        WeaponService _weaponService;
        Player Player;
        public GunTriggerFactory(GunTrigger triggerTemplate,
            WeaponService weaponService,
            Player player)
        {
            _name = triggerTemplate.Gun.Name;
            _triggerTemplate = triggerTemplate;
            _weaponService = weaponService;
            Player = player;
        }

        public string Name => _name;

        public GunTrigger CreateGunTrigger(Vector3 position)
        {
            var gunTrigger = GameObject.Instantiate(_triggerTemplate,
                position, Quaternion.identity, null);

            gunTrigger.InitializeWeaponService(_weaponService);
            gunTrigger.Initialize(Player);
            return gunTrigger;
        }
    }
}

using BonusesLojic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class GunTrigger : BonusTrigger
    {
        [SerializeField] private Gun _gun;
        public IGun Gun => _gun;

        WeaponService _weaponService;
        public void InitializeWeaponService(WeaponService weaponService)
        {
            _weaponService = weaponService;
        }
        protected override void OnPlayerTriggered()
        {
            base.OnPlayerTriggered();

            _weaponService.SwitchWeapon(_gun.name);

            Destroy(gameObject);
        }
    }
}

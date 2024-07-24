using GameInput;
using PlayerCode;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class WeaponService : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;
        
        List<IWeapon> _weaponList;

        IWeapon _currentWeapon;
        IWeapon _lastWeapon;
        IShootInput _shootInput;

        public bool HasWeapon
        {
            get
            {
                return _currentWeapon != null;
            }
        }

        public void Initialize(Player player, IShootInput shootInput)
        {
            _weaponList = new List<IWeapon>(_weapons);
            _shootInput = shootInput;
            _shootInput.Enable();
        }

        public void Update()
        {
            if(_shootInput.IsShoot())
            {
                _currentWeapon?.Shoot();
            }
        }

        public void SwitchWeapon(string gunName)
        {
            IWeapon newWeapon = null;
            foreach (IWeapon weapon in _weaponList)
            {
                if (weapon.Gun.Name == gunName)
                {
                    newWeapon = weapon;
                    break;
                }
            }
            _lastWeapon = _currentWeapon;

            _currentWeapon = newWeapon;

            if (_lastWeapon != null)
            {
                _lastWeapon.GetObject().SetActive(false);

                if (_lastWeapon is Weapon weaponn)
                {
                    weaponn.OnSwitch();
                }
            }

            _currentWeapon.GetObject().SetActive(true);
        }
        public IWeapon GetCurrentWeapon()
        {
            return _currentWeapon;
        }
        public List<IWeapon> GetWeapons()
        {
            return _weaponList;
        }
    }
}

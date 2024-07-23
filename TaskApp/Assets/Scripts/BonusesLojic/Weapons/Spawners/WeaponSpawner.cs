using PlayerCode;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class WeaponSpawner
    {
        const float c_spawnTime = 10f;

        WeaponService _weaponService;
        Player _player;
        WeaponTriggerFactoryProvider _weaponTriggerFactories;
        CameraVisability _cameraVisability;
        List<IWeapon> _weapons;

        float _currentTime;

        public WeaponSpawner(WeaponService weaponService,
            Player player, CameraVisability cameraVisability,
            WeaponTriggerFactoryProvider factoryProvider)
        {
            _weaponService = weaponService;
            _player = player;
            _cameraVisability = cameraVisability;
            _weaponTriggerFactories = factoryProvider;
            _weapons = _weaponService.GetWeapons();
        }

        public void Update(float ticks)
        {
            _currentTime += ticks;

            if (_currentTime >= c_spawnTime)
            {
                _currentTime = 0;

                var weaponsForSpawn = FormWeaponsList();

                int randomIndex = Random.Range(0, weaponsForSpawn.Count);

                var gun = weaponsForSpawn[randomIndex].Gun;

                var factory = _weaponTriggerFactories.Get(gun.Name);

                var point = GetRandomVisiblePoint();

                factory.CreateGunTrigger(point);
            }
        }

        List<IWeapon> FormWeaponsList()
        {
            var currentWeapon = _weaponService.GetCurrentWeapon();
            if(currentWeapon == null)
            {
                return _weapons;
            }
            var weapons = new List<IWeapon>(_weapons);

            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Gun.Name == currentWeapon.Gun.Name)
                {
                    weapons.Remove(weapons[i]);
                    break;
                }
            }

            return weapons;
        }

        Vector3 GetRandomVisiblePoint()
        {
            var visiblePointsList = _cameraVisability.GetVisiblePoints();

            int randomIndex = Random.Range(0, visiblePointsList.Count);

            return visiblePointsList[randomIndex];
        }

    }

}


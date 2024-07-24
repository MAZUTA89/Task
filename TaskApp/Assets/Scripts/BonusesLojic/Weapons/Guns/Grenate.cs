using EnemyLogic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class Grenate : Weapon
    {
        [SerializeField] private EnemyService _enemyService;
        [SerializeField] private GrenateBullet _bullet;

        protected override void BulletsShoot()
        {
            Vector3 mousePosition = MouseExtention.GetMousePosition();
            var bullet = Instantiate(_bullet,
                transform.position,
                Quaternion.identity, null);

            bullet.Initialize(mousePosition, _enemyService,
                Gun.Damage);
        }
    }
}

using EnemyLogic;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class ShotGun : Weapon
    {
        public int pelletCount = 5;
        public float spreadAngle = 10f; 
        protected override void BulletsShoot()
        {
            for (int i = 0; i < pelletCount; i++)
            {
                float angle = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                Vector3 direction = rotation * BulletTarget.forward;

                Ray ray = new Ray(BulletTarget.position, direction);

                if (Physics.Raycast(ray, out RaycastHit hitInfo, Gun.Range))
                {
                    Debug.DrawRay(BulletTarget.position, direction * hitInfo.distance, Color.red, 1f);
                    if (hitInfo.collider.gameObject.TryGetComponent(out IEnemy enemy))
                    {
                        enemy.TakeDamage(Gun.Damage);
                    }
                }
                else
                {
                    Debug.DrawRay(BulletTarget.position, direction * Gun.Range, Color.red, 1f); 
                }
            }
        }
    }
}

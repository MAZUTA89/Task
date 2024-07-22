using GameSO;
using PlayerCode;
using UnityEngine.UI;

namespace BonusLogic.Boosts
{
    public class SpeedBoost : Boost
    {
        float _speedRatio = 1.5f;
        PlayerMovement _movement;

        float _speed;
        public SpeedBoost(Player player, Image boostImage,
            SpeedBoostSO speedBonusSO) : base(player, boostImage)
        {
            _movement = player.PlayerMovement;
            _speedRatio = speedBonusSO.SpeedRatio;
            ActionTime = speedBonusSO.ActiveTime;
            _speed = _movement.MovementSpeed * _speedRatio;
        }

        public override void OnBoostActive()
        {
            _movement.ChangeSpeed(_speed);
        }

        public override void OnBoostFinished()
        {
            _movement.ResetSpeed();
        }
    }
}

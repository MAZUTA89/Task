using BonusLogic.Boosts;
using PlayerCode;
using UnityEngine.UI;

namespace BonusLogic
{
    public abstract class Boost : IBoost
    {
        protected Player Player;
        public float ActionTime { get ; set ; }
        public bool IsActive { get ; set ; }
        public Image Image { get; set; }

        float _currentTime;

        public Boost(Player player, Image boostImage)
        {
            Player = player;
            Image = boostImage;
            IsActive = true;
        }

        public void Update(float ticks)
        {
            if (IsActive)
            {
                _currentTime += ticks;
                OnBoostActive();
            }

            if(_currentTime >= ActionTime && IsActive)
            {
                IsActive = false;
                OnBoostFinished();
            }
            Image.gameObject.SetActive(IsActive);
        }

        public abstract void OnBoostActive();
        public abstract void OnBoostFinished();
    }
}

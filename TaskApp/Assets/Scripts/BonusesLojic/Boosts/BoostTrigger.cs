using BonusLogic;
using PlayerCode;
using UnityEngine;

namespace BonusLogic.Boosts
{
    public class BoostTrigger : MonoBehaviour
    {
        protected Player Player;
        protected PlayerBoosts PlayerBoosts;
        public void Initialize(Player player)
        {
            Player = player;
            PlayerBoosts = Player.PlayerBoosts;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Player.PlayerTag))
            {
                ActivateBoost();

                Destroy(gameObject);
            }
        }

        public virtual void ActivateBoost()
        {
        }


    }
}

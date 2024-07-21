using PlayerCode;
using UnityEngine;

namespace DangerZoneCode
{
    public abstract class DangerZone : MonoBehaviour
    {
        protected PlayerMovement PlayerMovement { get; private set; }
        protected Player Player { get; private set; }
        public void Initialize(Player player)
        {
            Player = player;
            PlayerMovement = Player.PlayerMovement;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Player.PlayerTag))
            {
                OnPlayerEnter(PlayerMovement);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Player.PlayerTag))
            {
                OnPlayerExit(PlayerMovement);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Player.PlayerTag))
            {
                OnPlayerStay(PlayerMovement);
            }
        }

        protected abstract void OnPlayerEnter(PlayerMovement playerMovement);
        protected abstract void OnPlayerExit(PlayerMovement playerMovement);
        protected abstract void OnPlayerStay(PlayerMovement playerMovement);
    }
}
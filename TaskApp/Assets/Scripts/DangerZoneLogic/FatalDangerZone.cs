using BonusLogic;
using BonusLogic.Boosts;
using BootLogic;
using GameUI;
using PlayerCode;
using System;

namespace DangerZoneCode
{
    public class FatalDangerZone : DangerZone
    {
        PlayerBoosts _playerBoosts;
        private void Start()
        {
            _playerBoosts = Player.PlayerBoosts;
        }
        protected override void OnPlayerEnter(PlayerMovement playerMovement)
        {
            if(!_playerBoosts.IsBoostActive<ShieldBoost>())
            {
                GameEvents.InvokeEndGameEvent();
            }
            
        }

        protected override void OnPlayerExit(PlayerMovement playerMovement)
        {
        }

        protected override void OnPlayerStay(PlayerMovement playerMovement)
        {
        }
    }
}

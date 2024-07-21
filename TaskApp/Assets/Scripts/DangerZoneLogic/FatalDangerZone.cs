using BootLogic;
using GameUI;
using PlayerCode;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace DangerZoneCode
{
    public class FatalDangerZone : DangerZone
    {
        FinalGamePanel _finalGamePanel;
        private void Start()
        {
            _finalGamePanel = GameCore.Instance().UI.FinalGamePanel;
        }
        protected override void OnPlayerEnter(PlayerMovement playerMovement)
        {
            //Time.timeScale = 0f;
            _finalGamePanel.Active();
            PlayerMovement.Lock();
        }

        protected override void OnPlayerExit(PlayerMovement playerMovement)
        {
        }

        protected override void OnPlayerStay(PlayerMovement playerMovement)
        {
        }
    }
}

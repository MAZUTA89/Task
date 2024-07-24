using BootLogic;
using GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuSceneInitialization
{
    public class MainMenuSceneInstaller : MonoBehaviour
    {
        MainMenuPanel _mainMenuPanel;
        private void Start()
        {
            _mainMenuPanel = GameCore.Instance().UI.MainMenuPanel;
            _mainMenuPanel.Activate();

            int gameScore = GameCore.Instance().GameScore.Score;

            _mainMenuPanel.ScoreValueText.text = gameScore.ToString();
        }
    }
}
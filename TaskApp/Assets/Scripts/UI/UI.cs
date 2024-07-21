using SceneSwitch;
using System;
using UnityEngine;


namespace GameUI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private FinalGamePanel _finalGamePanel;
        [SerializeField] private GamePanel _gamePanel;
        [SerializeField] private MainMenuPanel _mainMenuPanel;

        public FinalGamePanel FinalGamePanel => _finalGamePanel;
        public GamePanel GamePanel => _gamePanel;
        public MainMenuPanel MainMenuPanel => _mainMenuPanel;

        SceneSwitcher _sceneSwitcher;
        public void Initialize(SceneSwitcher sceneSwitcher)
        {
            _sceneSwitcher = sceneSwitcher;

            FinalGamePanel.Initialize(sceneSwitcher);
            FinalGamePanel.Deactivate();

            MainMenuPanel.Initialize(sceneSwitcher);
            GamePanel.Initialize(sceneSwitcher);
            GamePanel.Deactivate();
        }

    }
}

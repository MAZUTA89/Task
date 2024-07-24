using SceneSwitch;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private TextMeshProUGUI _scoreValueText;
        public Button StartButton => _startButton;
        public TextMeshProUGUI ScoreValueText => _scoreValueText;
        SceneSwitcher _sceneSwitcher;
        public void Initialize(SceneSwitcher sceneSwitcher)
        {
            _sceneSwitcher = sceneSwitcher;
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStart);
        }
        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStart);
        }

        void OnStart()
        {
            Deactivate();
            _sceneSwitcher.SwitchScene(GameConfig.GameSceneName);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}

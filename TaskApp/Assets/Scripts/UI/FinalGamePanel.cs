using SceneSwitch;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class FinalGamePanel : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;

        [SerializeField] private TextMeshProUGUI _scoreValueText;
        [SerializeField] private GameObject _newRecordText;

        public Button MenuButton => _menuButton;
        public Button RestartButton => _restartButton;
        public TextMeshProUGUI ScoreValueText => _scoreValueText;
        public GameObject NewRecordText => _newRecordText;

        SceneSwitcher _sceneSwitcher;
        
        public void Initialize(SceneSwitcher sceneSwitcher)
        {
            _sceneSwitcher = sceneSwitcher;
            NewRecordText.SetActive(false);
        }
        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenu);
            _restartButton.onClick.AddListener(OnRestart);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnMenu);
            _restartButton.onClick.RemoveListener(OnRestart);
        }

        void OnRestart()
        {
            Deactivate();
            _sceneSwitcher.LoadCurrentScene();
        }

        void OnMenu()
        {
            Deactivate();
            _sceneSwitcher.SwitchScene(GameConfig.MenuSceneName);
        }
        public void Active()
        {
            gameObject.SetActive(true);
        }
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}

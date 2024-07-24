using SceneSwitch;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] Button _menuButton;
        [SerializeField] TextMeshProUGUI _scoreValueText;
        [SerializeField] CanvasGroup _canvasGroup;

        public Button MenuButton => _menuButton;
        public TextMeshProUGUI ScoreValueText => _scoreValueText;

        public CanvasGroup CanvasGroup => _canvasGroup;
        
        SceneSwitcher _sceneSwitcher;
        public void Initialize(SceneSwitcher sceneSwitcher)
        {
            _sceneSwitcher = sceneSwitcher;
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenu);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        void OnMenu()
        {
            _sceneSwitcher.SwitchScene(GameConfig.MenuSceneName);
            Deactivate();
        }
    }
}
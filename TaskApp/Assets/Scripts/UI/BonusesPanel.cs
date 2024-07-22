
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class BonusesPanel : MonoBehaviour
    {
        [SerializeField] private Image _speedImage;
        [SerializeField] private Image _sheildImage;
        public Image SpeedImage => _speedImage;
        public Image SheildImage => _sheildImage;
    }
}

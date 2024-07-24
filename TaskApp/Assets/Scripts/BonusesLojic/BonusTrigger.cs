using PlayerCode;
using UnityEngine;

namespace BonusesLojic
{
    public abstract class BonusTrigger : MonoBehaviour
    {
        [SerializeField] private float _liveTime;
        float _currentLiveTime;
        protected Player Player;
        public virtual void Initialize(Player player)
        {
            Player = player;
        }

        private void Update()
        {
            _currentLiveTime += Time.deltaTime;

            if(_currentLiveTime >= _liveTime)
            {
                _currentLiveTime = 0;
                Destroy(gameObject);
            }
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Player.PlayerTag))
            {
                OnPlayerTriggered();

                Destroy(gameObject);
            }
        }

        protected virtual void OnPlayerTriggered()
        {

        }
    }
}

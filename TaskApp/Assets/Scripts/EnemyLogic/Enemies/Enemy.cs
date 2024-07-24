using BonusLogic;
using BonusLogic.Boosts;
using GameSO;
using PlayerCode;
using Score;

using UnityEngine;
using UnityEngine.AI;

namespace EnemyLogic
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour, IEnemy
    {
        const float c_rotationSpeed = 400f;

        [SerializeField] private EnemySO _enemySO;
        NavMeshAgent _agent;
        public int HP
        {
            get
            {
                return _currentHP;
            }
            set
                
            {
                if (value < 1)
                {
                    _currentHP = 0;
                }
                else
                {
                    _currentHP = value;
                }
            }
            
        }
        public int ScorePoints => _enemySO.ScorePoints;

        public float SpawnChance => _enemySO.SpawnChance;

        Transform _playerTransform;
        EnemyService _enemyService;
        GameScore _gameScore;
        int _currentHP;
        Vector3 _direction;

        PlayerBoosts _playerBoosts;

        public virtual void Initialize(Player player,
            EnemyService enemyService, GameScore gameScore)
        {
            _playerTransform = player.PlayerTransform;
            _playerBoosts = player.PlayerBoosts;
            _enemyService = enemyService;
            _gameScore = gameScore;

            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = _enemySO.Speed;
        }

        private void Start()
        {
            _currentHP = _enemySO.HP;
            _enemyService.AddEnemy(this);
        }

        private void Update()
        {
            _agent.destination = _playerTransform.position;
            
           
            if(Vector3.Distance(_playerTransform.position,
                transform.position) <= _enemySO.CatchDistance)
            {
                if(!_playerBoosts.IsBoostActive<ShieldBoost>())
                {
                    GameEvents.InvokeEndGameEvent();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        
        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            if(HP == 0)
            {
                _gameScore.AddScore(_enemySO.ScorePoints);
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            _enemyService.RemoveEnemy(this);
        }

    }
}

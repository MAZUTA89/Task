using GameSO;
using Score;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace EnemyLogic
{
    [RequireComponent(typeof(CharacterController))]
    public class Enemy : MonoBehaviour, IEnemy
    {
        const float c_rotationSpeed = 400f;

        [SerializeField] private EnemySO _enemySO;
        CharacterController _characterController;
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

        public virtual void Initialize(Transform playerTransform,
            EnemyService enemyService, GameScore gameScore)
        {
            _playerTransform = playerTransform;
            _enemyService = enemyService;
            _gameScore = gameScore;

            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _currentHP = _enemySO.HP;
            _enemyService.AddEnemy(this);
        }

        private void Update()
        {
            

            Quaternion targetRotation = Quaternion.LookRotation(_direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, targetRotation, c_rotationSpeed * Time.deltaTime);
           
            if(Vector3.Distance(_playerTransform.position,
                transform.position) <= _enemySO.CatchDistance)
            {
                Debug.Log("Поймал!");
                Destroy(gameObject);
                return;
            }
        }
        private void LateUpdate()
        {
            _direction = _playerTransform.position -
                transform.position;

            _direction = new Vector3(_direction.x, 0, _direction.z).normalized;

            _characterController.Move(_direction * Time.deltaTime
                * _enemySO.Speed);
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

using EnemyLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BonusLogic.Weapon
{
    public class GrenateBullet : MonoBehaviour
    {
        public float sphereSpeed = 5f;
        Vector3 _targetPosition;
        EnemyService _service;
        Vector3 _startPosition;
        float _length;
        float _startTime;
        float _damageRadius = 2f;
        int _damage;
        public void Initialize(Vector3 targetPosition,
            EnemyService enemyService, int damage)
        {
            _targetPosition = targetPosition;
            _service = enemyService;
            _damage = damage;
        }

        private void Start()
        {
            _startPosition = gameObject.transform.position;
            _length = Vector3.Distance(_startPosition, _targetPosition);
            _startTime = Time.time;
        }

        private void Update()
        {
            if(Vector3.Distance(gameObject.transform.position, _targetPosition) > 0.1f)
            {
                float distCovered = (Time.time - _startTime) * sphereSpeed;
                float fractionOfJourney = distCovered / _length;

                Vector3 center = (_startPosition + _targetPosition) * 0.5f;
                center.y -= 8.0f;

                Vector3 riseRelCenter = _startPosition - center;
                Vector3 setRelCenter = _targetPosition - center;

                gameObject.transform.position = Vector3.Slerp(riseRelCenter,
                    setRelCenter, fractionOfJourney) + center;
            }
            else
            {
                RaycastHit[] hits = Physics.SphereCastAll(_targetPosition,
                    _damageRadius, transform.forward);

                foreach (var hit in hits)
                {
                    if(hit.collider.gameObject.TryGetComponent(out IEnemy enemy))
                    {
                        enemy.TakeDamage(_damage);
                        Debug.Log(hit.collider.name);
                    }
                }

                Destroy(gameObject);
            }
        }

        private IEnumerator MoveSphereToPosition(GameObject sphere, Vector3 targetPosition)
        {
            Vector3 startPosition = sphere.transform.position;
            float journeyLength = Vector3.Distance(startPosition, targetPosition);
            float startTime = Time.time;

            while (Vector3.Distance(sphere.transform.position, targetPosition) > 0.1f)
            {
                float distCovered = (Time.time - startTime) * sphereSpeed;
                float fractionOfJourney = distCovered / journeyLength;

                Vector3 center = (startPosition + targetPosition) * 0.5f;
                center.y += 5.0f; 

                Vector3 riseRelCenter = startPosition - center;
                Vector3 setRelCenter = targetPosition - center;

                sphere.transform.position = Vector3.Slerp(riseRelCenter,
                    setRelCenter, fractionOfJourney) + center;

                yield return null;
            }
        }
    }
}

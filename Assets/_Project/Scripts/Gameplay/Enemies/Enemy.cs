using System;
using _Project.Scripts.Gameplay.Attributes;
using _Project.Scripts.Gameplay.Configs.Enemy;
using _Project.Scripts.Gameplay.Enums;
using _Project.Scripts.Gameplay.Player;
using SirGames.Scripts.Gameplay.Enemies;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Enemies
{
    public class Enemy : MonoBehaviour, Health
    {
        private const int PLAYER = 6;
        private const int FLY = 2;

        public event Action<Enemy> OnDead;

        [SerializeField] private Transform _shotPosition;
        [SerializeField] private TrackingTarget _trackingTarget;

        public int HealthAmount { get; private set; }

        private TrafficState _trafficState = TrafficState.Stay;

        private EnemyConfigData _configData;

        public bool IsDead { get; set; }

        private bool _isCanAttack;
        private Vector3 _previousPosition;
        private float _timeToNextAttack;

        public void Initialize(EnemyConfigData configData)
        {
            _configData = configData;
            EnemyType = _configData.Type;
            HealthAmount = configData.HealthAmount;
        }

        public EnemyType EnemyType { get; set; }

        private void Start()
        {
            if (_configData.Type == EnemyType.FlyEnemy)
            {
                transform.position += Vector3.up * FLY;
            }
        }

        private void FixedUpdate()
        {
            IdentifyIsCanAttack();
            IdentifyTrafficState();
        }

        private void IdentifyIsCanAttack()
        {
            if (!_isCanAttack)
            {
                _timeToNextAttack += Time.deltaTime;
                if (_timeToNextAttack >= _configData.FireRate)
                {
                    _isCanAttack = true;
                    _timeToNextAttack = 0;
                }
            }
        }

        private void IdentifyTrafficState()
        {
            _trafficState = _previousPosition != transform.position ? TrafficState.Move : TrafficState.Stay;
            _previousPosition = transform.position;
        }

        private void OnTriggerStay(Collider col)
        {
            if (col.gameObject.layer == PLAYER)
            {
                DoDamage(col.transform);
                
                MoveToTarget(col.transform);
                _trackingTarget.LookOnTarget(col.transform);
            }
        }

        private void MoveToTarget(Transform target)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer >= _configData.RadiusAttack)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                direction.y = 0;
                transform.position += direction * _configData.MovementSpeed * Time.deltaTime;
            }
        }

        public void GetDamage(int damage)
        {
            HealthAmount -= damage;
            if (HealthAmount <= 0)
            {
                Dead();
            }
        }

        private void Dead()
        {
            OnDead?.Invoke(this);
            Destroy(gameObject);
        }

        private void DoDamage(Transform targetPosition)
        {
            if (_trafficState == TrafficState.Stay && _isCanAttack)
            {
                _isCanAttack = false;
                Instantiate(_configData.Bullet, _shotPosition.position, Quaternion.identity)
                    .Shot(targetPosition, _configData.ForceShot, _configData.DamageAmount);
            }
        }
    }
}
using _Project.Scripts.Gameplay.Configs.Player;
using _Project.Scripts.Gameplay.Enemies;
using _Project.Scripts.Gameplay.Enums;
using _Project.Scripts.Infrastructure.StaticData;
using SirGames.Scripts.Gameplay.Attributes;
using SirGames.Scripts.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.Player
{
    public class Player : MonoBehaviour, IPlayer, Health
    {
        private const int ENEMY = 7;

        [SerializeField] private SphereCollider _detectedCollider;
        [SerializeField] private Transform _shotPosition;
        [SerializeField] private TrackingTarget _trackingTarget;

        private PlayerConfig Config;

        private TrafficState _trafficState = TrafficState.Stay;

        public int HealthAmount { get; private set; }
        public bool IsDead { get; private set; }

        private bool _isCanAttack;
        private Transform _target;

        private float _timeToNextAttack;

        private Vector3 _previousPosition;

        [Inject]
        private void Construct(GameStaticData gameStaticData)
        {
            Config = gameStaticData.GetPlayerConfig();
        }

        private void Start()
        {
            _detectedCollider.radius = Config.DetectedRadius;
            HealthAmount = Config.Health;
            _previousPosition = transform.position;
        }

        private void FixedUpdate()
        {
            IdentifyTrafficState();
            IdentifyIsCanAttack();
        }

        private void IdentifyIsCanAttack()
        {
            if (!_isCanAttack)
            {
                _timeToNextAttack += Time.deltaTime;
                if (_timeToNextAttack >= Config.FiringRate)
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
            if (col.gameObject.layer == ENEMY)
            {
                InitializeTarget(col);
            }
        }

        private void InitializeTarget(Collider col)
        {
            DoDamage(col.gameObject.transform);
            _trackingTarget.LookOnTarget(_target);
        }

        public void GetDamage(int damage)
        {
            HealthAmount -= damage;
            IsDead = HealthAmount <= 0;

            if (IsDead)
            {
                Dead();
            }

            Debug.Log($"Player: GetDamage {damage} | Health {HealthAmount}");
        }

        private void Dead()
        {
            gameObject.SetActive(false);
        }

        private void DoDamage(Transform targetPosition)
        {
            if (_trafficState == TrafficState.Stay && _isCanAttack)
            {
                _target = targetPosition;

                _isCanAttack = false;
                Instantiate(Config.Bullet, _shotPosition.position, Quaternion.identity)
                    .Shot(targetPosition, Config.ForceShot, Config.Attack);
            }
        }
    }
}
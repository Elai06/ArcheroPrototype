using System;
using _Project.Scripts.Gameplay.Attributes;
using _Project.Scripts.Gameplay.Configs.Guns;
using _Project.Scripts.Gameplay.Configs.Player;
using _Project.Scripts.Gameplay.Enums;
using _Project.Scripts.Gameplay.UI.Inventory.Guns;
using _Project.Scripts.Infrastructure.PersistenceProgress;
using _Project.Scripts.Infrastructure.StaticData;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.Player
{
    public class Player : MonoBehaviour, IPlayer, Health
    {
        private const int ENEMY = 7;

        [SerializeField] private TrackingTarget _trackingTarget;
        [SerializeField] private SphereCollider _detectedCollider;
        [SerializeField] private Transform _gunPosition;
        [SerializeField] private TextMeshPro _healthText;

        private PlayerConfig Config;
        private IGunsInventoryModel _gunsInventory;
        private GunsConfigData _gunConfig;
        private GunSpawner _gunSpawner;
        private IProgressService _progressService;

        private bool _isCanAttack;
        private float _timeToNextAttack;
        private Vector3 _previousPosition;
        private Transform _target;
        private TrafficState _trafficState = TrafficState.Stay;

        public int HealthAmount { get; private set; }
        public bool IsDead { get; private set; }

        public Transform GunPosition => _gunPosition;

        [Inject]
        private void Construct(GameStaticData gameStaticData, IGunsInventoryModel gunsInventoryModel,
            GunSpawner gunSpawner, IProgressService progressService)
        {
            Config = gameStaticData.GetPlayerConfig();
            _gunsInventory = gunsInventoryModel;
            _gunSpawner = gunSpawner;
            _progressService = progressService;
        }

        private void Start()
        {
            _detectedCollider.radius = Config.DetectedRadius;
            _previousPosition = transform.position;
            HealthAmount = Config.Health;
            
            HealthView(HealthAmount);
        }

        private void OnEnable()
        {
            _progressService.OnLoaded += Loaded;
            _gunsInventory.OnEquipped += Equipped;
        }

        private void OnDisable()
        {
            _progressService.OnLoaded -= Loaded;
            _gunsInventory.OnEquipped += Equipped;
        }

        private void Equipped()
        {
            _gunConfig = _gunsInventory.GetEquippedGun();
        }

        private void Loaded()
        {
            _gunConfig = _gunsInventory.GetEquippedGun();
            _gunSpawner.SpawnGun();
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
                if (_timeToNextAttack >= _gunConfig.FireRate)
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

            HealthView(HealthAmount);
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
                var shotPosition = _gunSpawner.GetEquippedGun().GetShotPosition();

                Instantiate(Config.Bullet, shotPosition.position, Quaternion.identity)
                    .Shot(targetPosition, _gunConfig.ForceShot, _gunConfig.Damage);
            }
        }
        
        private void HealthView(int hp)
        {
            _healthText.text = hp.ToString();
        }
    }
}
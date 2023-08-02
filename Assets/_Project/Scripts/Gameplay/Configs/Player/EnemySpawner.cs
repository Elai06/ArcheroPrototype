using System.Collections.Generic;
using _Project.Scripts.Gameplay.Configs.Enemy;
using _Project.Scripts.Gameplay.Models.Currency;
using _Project.Scripts.Gameplay.Models.Resource;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Gameplay.Configs.Player
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<Enemies.Enemy> Enemies = new();

        [SerializeField] private int _enemiesCount = 2;
        [SerializeField] private EnemyConfigs _enemyConfigs;
        [SerializeField] private float _maxPositionX;
        [SerializeField] private float _maxPositionZ;

        private ICurrenciesModel _currenciesModel;

        [Inject]
        public void Construct(ICurrenciesModel currenciesModel)
        {
            _currenciesModel = currenciesModel;
        }

        private void Start()
        {
            SpawnEnemies(_enemiesCount);
        }

        public void SpawnEnemies(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var randomIndex = Random.Range(0, amount);
                var enemyConfig = _enemyConfigs.EnemyConfigData[randomIndex];

                var prefab = Instantiate(enemyConfig.Enemy, GetRandomPosition(), Quaternion.identity,
                    transform);
                var enemy = prefab.transform.gameObject.GetComponentInChildren<Enemies.Enemy>();
                enemy.Initialize(enemyConfig);
                enemy.OnDead += EnemyDead;
                Enemies.Add(enemy);
            }
        }

        private void EnemyDead(Enemies.Enemy enemy)
        {
            Enemies.Remove(enemy);
            _currenciesModel.Add(CurrencyType.SoftCurrency, 5);
            if (Enemies.Count == 0)
            {
                SpawnEnemies(_enemiesCount);
            }
        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(-_maxPositionX, _maxPositionX), 0, Random.Range(0, _maxPositionZ));
        }
    }
}
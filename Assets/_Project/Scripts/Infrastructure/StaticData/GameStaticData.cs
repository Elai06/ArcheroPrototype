using _Project.Scripts.Gameplay.Configs.Enemy;
using _Project.Scripts.Gameplay.Configs.Player;
using _Project.Scripts.Infrastructure.Windows;
using Infrastructure.Windows;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "GameStaticData", menuName = "Configs/GameStaticData")]
    public class GameStaticData : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyConfigs _enemyConfigs;

        [SerializeField] private WindowsStaticData _windowsStaticData;
        
        public PlayerConfig GetPlayerConfig() => _playerConfig;

        public EnemyConfigs GetEnemyConfig() => _enemyConfigs;

        public Window GetWindowData(WindowType windowType)
        {
            return _windowsStaticData.WindowsData.Find(x => x.WindowType == windowType).Window;
        }
    }
}
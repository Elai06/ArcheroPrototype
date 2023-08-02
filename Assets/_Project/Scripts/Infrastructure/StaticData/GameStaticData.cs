using _Project.Scripts.Gameplay.Configs.Enemy;
using _Project.Scripts.Gameplay.Configs.Guns;
using _Project.Scripts.Gameplay.Configs.Player;
using _Project.Scripts.Gameplay.UI.Inventory.Guns;
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
        [SerializeField] private GunsConfig _gunsConfig;

        [SerializeField] private WindowsStaticData _windowsStaticData;
        
        public PlayerConfig GetPlayerConfig() => _playerConfig;
        public GunsConfig GetGunsConfig() => _gunsConfig;

        public EnemyConfigs GetEnemyConfig() => _enemyConfigs;

        public WindowData GetWindowData(WindowType windowType)
        {
            return _windowsStaticData.GetWindows().Find(x => x.WindowType == windowType);
        }

        public GunsConfigData GetGunConfig(GunsType type)
        {
            return _gunsConfig.GetGun(type);

        }
    }
}
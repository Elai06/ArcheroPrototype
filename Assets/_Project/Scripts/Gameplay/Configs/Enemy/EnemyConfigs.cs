using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Configs.Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfigs", menuName = "Configs/Enemy")]
    public class EnemyConfigs : ScriptableObject
    {
        public List<EnemyConfigData> EnemyConfigData = new();
    }
}
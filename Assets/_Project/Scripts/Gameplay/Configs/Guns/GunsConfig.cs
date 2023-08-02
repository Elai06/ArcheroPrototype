using System.Collections.Generic;
using _Project.Scripts.Gameplay.UI.Inventory.Guns;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Configs.Guns
{
    [CreateAssetMenu(fileName = "GunsConfig", menuName = "Config/Guns")]
    public class GunsConfig : ScriptableObject
    {
        [SerializeField] private List<GunsConfigData> _gunsConfig;

        public List<GunsConfigData> Config => _gunsConfig;

        public GunsConfigData GetGun(GunsType type)
        {
            return _gunsConfig.Find(x => x.Type == type);
        }
    }
}
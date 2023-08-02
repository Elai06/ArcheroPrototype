using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay.Configs.Guns;

namespace _Project.Scripts.Gameplay.UI.Inventory.Guns
{
    public interface IGunsInventoryModel
    {
        GunsConfigData GetEquippedGun();
        event Action OnEquipped;
        GunsConfig GunsConfig { get; }
        List<GunData> GetGunsProgresses();
        void Equip(bool isEquip, GunsType type);
    }
}
using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay.Models.Resource;
using _Project.Scripts.Gameplay.UI.Inventory.Guns;

namespace _Project.Scripts.Infrastructure.PersistenceProgress
{
    [Serializable]
    public class PlayerProgress
    {
        public List<CurrencyData> CurrencyDataProgress = new();
        public List<GunData> GunsDataProgress;

        public PlayerProgress()
        {
            GunsDataProgress = new List<GunData>
            {
                new()
                {
                    GunsType = GunsType.Pistol.ToString(),
                    isEquipped = true
                }
            };
        }
    }
}
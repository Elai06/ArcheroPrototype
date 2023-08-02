using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Gameplay.Configs.Guns;
using _Project.Scripts.Infrastructure.PersistenceProgress;
using _Project.Scripts.Infrastructure.StaticData;
using Zenject;

namespace _Project.Scripts.Gameplay.UI.Inventory.Guns
{
    public class GunsInventoryModel : IGunsInventoryModel
    {
        public event Action OnEquipped;

        private readonly IProgressService _progressService;
        private readonly GameStaticData _gameStaticData;

        public GunsConfig GunsConfig { get; }

        public GunsInventoryModel(IProgressService progressService, GameStaticData gameStaticData)
        {
            _progressService = progressService;
            _gameStaticData = gameStaticData;
            GunsConfig = gameStaticData.GetGunsConfig();
            
            _progressService.OnLoaded += Loaded;
        }
        
        private void Loaded()
        {
            _progressService.OnLoaded -= Loaded;

            InitializeGunsProgresses();
        }

        private void InitializeGunsProgresses()
        {
            foreach (var gunConfig in GunsConfig.Config)
            {
                var gunsDataProgresses = _progressService.PlayerProgress.GunsDataProgress;
                if (gunsDataProgresses.Find(x => x.GunsType == gunConfig.Type.ToString()) == null)
                {
                    gunsDataProgresses.Add(new GunData()
                    {
                        GunsType = gunConfig.Type.ToString(),
                        isEquipped = false,
                    });
                }
            }
        }

        public GunsConfigData GetEquippedGun()
        {
            foreach (var gunProgress in _progressService.PlayerProgress.GunsDataProgress)
            {
                if (gunProgress.isEquipped)
                {
                    return GunsConfig.GetGun(Enum.Parse<GunsType>(gunProgress.GunsType));
                }
            }

            return null;
        }

        public List<GunData> GetGunsProgresses()
        {
            return _progressService.PlayerProgress.GunsDataProgress;
        }

        public void Equip(bool isEquip, GunsType type)
        {
            var gunsProgresses = _progressService.PlayerProgress.GunsDataProgress;

            if (GetEquippedGun().Type == type)
            {
                return;
            }

            foreach (var gun in gunsProgresses)
            {
                gun.isEquipped = false;
            }

            gunsProgresses.Find(x => x.GunsType == type.ToString()).isEquipped = true;

            OnEquipped?.Invoke();
        }
    }
}
using System;
using _Project.Scripts.Infrastructure.PersistenceProgress;
using Infrastructure.SaveLoads;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.SaveLoads
{
    public class SaveLoadService : ISaveLoadService
    {
        public event Action OnLoaded; 

        private readonly IProgressService _progressService;

        public SaveLoadService(IProgressService progressService)
        {
            _progressService = progressService;
        }

        private const string SavesKey = "Saves";

        public void Load()
        {
            _progressService.InitializeProgress(GetOrCreate());
            _progressService.OnLoaded += Loaded;
        }

        public void Save()
        {
            PlayerPrefs.SetString(SavesKey, JsonUtility.ToJson(_progressService.PlayerProgress));
        }

        private PlayerProgress GetOrCreate()
        {
            if (PlayerPrefs.HasKey(SavesKey))
            {
                var saves = PlayerPrefs.GetString(SavesKey);
                return JsonUtility.FromJson<PlayerProgress>(saves);
            }

            return new PlayerProgress();
        }

        private void Loaded()
        {
            _progressService.OnLoaded -= Loaded;
            OnLoaded?.Invoke();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Gameplay.Models.Resource;
using _Project.Scripts.Infrastructure.PersistenceProgress;

namespace _Project.Scripts.Gameplay.Models.Currency
{
    public class CurrenciesModel : ICurrenciesModel
    {
        public event Action UpdateValue;

        private readonly IProgressService _progressService;

        public Dictionary<CurrencyType, CurrencyData> CurrenciesData { get; } = new();

        public CurrenciesModel(IProgressService progressService)
        {
            _progressService = progressService;

            progressService.OnLoaded += Loaded;
        }

        private void Loaded()
        {
            Initialize();
        }

        public void Initialize()
        {
            foreach (var currencyData in _progressService.PlayerProgress.CurrencyDataProgress)
            {
                CurrenciesData.Add(currencyData.CurrencyType, new CurrencyData
                {
                    CurrencyType = currencyData.CurrencyType,
                    Amount = currencyData.Amount
                });
            }
        }

        public void Add(CurrencyType type, int amount)
        {
            if (CurrenciesData.TryGetValue(type, out CurrencyData value))
            {
                value.Amount += amount;
            }
            else
            {
                CurrenciesData.TryAdd(type, new CurrencyData()
                {
                    CurrencyType = type,
                    Amount = amount,
                });
            }
            
            UpdateProgress();
            UpdateValue?.Invoke();
        }

        public void Consume(CurrencyType type, int amount)
        {
            if (CurrenciesData.TryGetValue(type, out CurrencyData value))
            {
                value.Amount -= amount;
            }
            UpdateProgress();
            UpdateValue?.Invoke();
        }

        private void UpdateProgress()
        {
            _progressService.PlayerProgress.CurrencyDataProgress = CurrenciesData.Values.ToList();
        }
    }

    public interface ICurrenciesModel
    {
        void Add(CurrencyType type, int amount);
        event Action UpdateValue;
        Dictionary<CurrencyType, CurrencyData> CurrenciesData { get; }
    }
}
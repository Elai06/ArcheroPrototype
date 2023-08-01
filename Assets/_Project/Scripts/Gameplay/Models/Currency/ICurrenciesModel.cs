using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay.Models.Resource;

namespace _Project.Scripts.Gameplay.Models.Currency
{
    public interface ICurrenciesModel
    {
        event Action UpdateValue;
        void Consume(CurrencyType type, int amount);
        void Add(CurrencyType type, int amount);
        Dictionary<CurrencyType, CurrencyData> CurrenciesData { get; }
    }
}
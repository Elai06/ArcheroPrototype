using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay.Models.Resource;

namespace _Project.Scripts.Infrastructure.PersistenceProgress
{
    [Serializable]
    public class PlayerProgress
    {
        public List<CurrencyData> CurrencyProgressData;
    }
}
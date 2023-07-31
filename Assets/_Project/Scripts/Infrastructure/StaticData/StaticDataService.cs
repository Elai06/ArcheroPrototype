using System;
using System.Collections.Generic;
using Infrastructure.Windows;
using SirGames.Scripts.StaticData;

namespace Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly Dictionary<WindowType, WindowStaticData> _windowsData = new();


        public void Load()
        {
            LoadConfigs();
        }

        public WindowStaticData GetWindowData(WindowType windowType)
        {
            if (_windowsData.TryGetValue(windowType, out var windowStaticData))
                return windowStaticData;

            throw new InvalidOperationException(
                $"WindowStaticData with type: {windowType} doesn't stored in StaticDataService");
        }


        private void LoadConfigs()
        {
        }
    }
}
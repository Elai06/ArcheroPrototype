using Infrastructure.Windows;

namespace SirGames.Scripts.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        public WindowStaticData GetWindowData(WindowType windowType);
    }
}
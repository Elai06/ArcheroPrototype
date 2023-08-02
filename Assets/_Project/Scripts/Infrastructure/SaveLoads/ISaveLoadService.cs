using System;

namespace Infrastructure.SaveLoads
{
    public interface ISaveLoadService
    {
        void Load();
        void Save();
        event Action OnLoaded;
    }
}
using System;

namespace _Project.Scripts.Infrastructure.PersistenceProgress
{
    public interface IProgressService
    {
        PlayerProgress PlayerProgress { get; }
        bool IsLoaded { get; }
        event Action OnLoaded; 
        void InitializeProgress(PlayerProgress playerProgress);
    }
}
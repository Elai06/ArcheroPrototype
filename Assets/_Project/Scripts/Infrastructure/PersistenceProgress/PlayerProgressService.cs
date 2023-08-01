using System;

namespace _Project.Scripts.Infrastructure.PersistenceProgress
{
    public class PlayerProgressService : IProgressService
    {
        public PlayerProgress PlayerProgress { get; private set; }
        public bool IsLoaded { get; set; }
        public event Action OnLoaded;

        public void InitializeProgress(PlayerProgress playerProgress)
        {
            PlayerProgress = playerProgress;

            IsLoaded = true;
            OnLoaded?.Invoke();
        }
    }
}
using Infrastructure.Windows;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.UI.Pause
{
    public class PauseWindow : Window
    {
        [SerializeField] private PauseViewInitializer _pauseViewInitializer;

        private PauseModel _pauseModel;

        [Inject]
        public void Construct(PauseModel pauseModel)
        {
            _pauseModel = pauseModel;
        }

        private void OnEnable()
        {
            _pauseViewInitializer.Initialize(_pauseModel);
        }
    }
}
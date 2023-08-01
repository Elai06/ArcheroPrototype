using _Project.Scripts.Infrastructure.Windows;
using UnityEngine;
using Zenject;

namespace Infrastructure.Windows
{
    public class OpenWindowButton : ButtonBase
    {
        [SerializeField] private WindowType _windowType;
        
        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }

        protected override void OnClick()
        {
            base.OnClick();
            
            _windowService.Open(_windowType);
        }
    }
}
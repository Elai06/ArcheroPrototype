using Zenject;

namespace Infrastructure.Windows
{
    public class CloseCurrentWindowButton : ButtonBase
    {
        private Window _window;

        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }
        
        public override void Awake()
        {
            base.Awake();
            _window = GetComponentInParent<Window>();
        }

        public override void OnClick()
        {
            _windowService.Close(_window.WindowType);
        }
    }
}
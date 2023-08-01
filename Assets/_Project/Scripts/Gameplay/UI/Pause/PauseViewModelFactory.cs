using Infrastructure.Windows.MVVM;

namespace _Project.Scripts.Gameplay.UI.Pause
{
    public class PauseViewModelFactory : IViewModelFactory<PauseViewModel, PauseView, PauseModel>
    {
        public PauseViewModel Create(PauseModel model ,PauseView view) => new(model, view);
    }
}
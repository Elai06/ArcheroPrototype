using System.Threading.Tasks;
using Infrastructure.Windows.MVVM;
using UnityEngine;

namespace _Project.Scripts.Gameplay.UI.Pause
{
    public class PauseViewModel : ViewModelBase<PauseModel, PauseView>
    {
        public PauseViewModel(PauseModel model, PauseView view) : base(model, view)
        {
            
        }

        public override Task Show()
        {
            return Task.CompletedTask;
        }
    }
}
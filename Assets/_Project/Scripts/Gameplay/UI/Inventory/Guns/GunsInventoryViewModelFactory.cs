using Infrastructure.Windows.MVVM;

namespace _Project.Scripts.Gameplay.UI.Inventory.Guns
{
    public class GunsInventoryViewModelFactory : IViewModelFactory<GunsInventoryViewModel, GunsInventoryView, IGunsInventoryModel>
    {
        public GunsInventoryViewModel Create(IGunsInventoryModel model, GunsInventoryView view)
        {
            return new GunsInventoryViewModel(model, view);
        }
    }
}
using System.Threading.Tasks;
using Infrastructure.Windows.MVVM;

namespace _Project.Scripts.Gameplay.UI.Inventory.Guns
{
    public class GunsInventoryViewModel : ViewModelBase<IGunsInventoryModel, GunsInventoryView>
    {
        public GunsInventoryViewModel(IGunsInventoryModel model, GunsInventoryView view) : base(model, view)
        {
        }

        public override Task Show()
        {
            InitializeGunsSubViews();
            return Task.CompletedTask;
        }

        public override void Subscribe()
        {
            base.Subscribe();

            Model.OnEquipped += Equipped;
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();

            Model.OnEquipped -= Equipped;
        }

        private void Equipped()
        {
            InitializeGunsSubViews();
        }

        private void InitializeGunsSubViews()
        {
            View.SubViewContainer.CleanUp();

            foreach (var gun in Model.GunsConfig.Config)
            {
                var progress = Model.GetGunsProgresses().Find(x => x.GunsType == gun.Type.ToString());

                var subViewData = new GunsInventorySubViewData
                {
                    Type = gun.Type,
                    Damage = gun.Damage.ToString(),
                    Sprite = gun.Sprite,
                    IsEquipped = progress?.isEquipped ?? false,
                    FireRate = gun.FireRate.ToString(),
                };
                
                View.SubViewContainer.Add(gun.Type.ToString(), subViewData);
                
               var subView = View.SubViewContainer.SubViews[gun.Type.ToString()];

               subView.OnEquip += Equip;
            }
        }

        public void Equip(GunsType type)
        {
            Model.Equip(true, type);
        }
    }
}
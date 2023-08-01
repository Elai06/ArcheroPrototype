using System.Threading.Tasks;
using _Project.Scripts.Gameplay.Models.Currency;
using _Project.Scripts.Gameplay.Models.Resource;
using Infrastructure.Windows.MVVM;

namespace _Project.Scripts.Gameplay.UI.Header
{
    public class CurrencyViewModel : ViewModelBase<ICurrenciesModel, CurrenciesView>
    {
        public CurrencyViewModel(ICurrenciesModel model, CurrenciesView view) : base(model, view)
        {
        }

        public override Task Show()
        {
            InitializeSubViews();
            
            return Task.CompletedTask;
        }

        private void InitializeSubViews()
        {
            View.CurrencySubViewContainer.CleanUp();
            foreach (var currency in Model.CurrenciesData.Values)
            {
                View.CurrencySubViewContainer.Add(currency.CurrencyType.ToString(), new CurrencyData
                {
                    CurrencyType = currency.CurrencyType,
                    Amount = currency.Amount,
                });
            }
        }

        public override void Subscribe()
        {
            base.Subscribe();

            Model.UpdateValue += OnUpdateValue;
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();

            Model.UpdateValue -= OnUpdateValue;
        }

        private void OnUpdateValue()
        {
            InitializeSubViews();
        }
    }
}
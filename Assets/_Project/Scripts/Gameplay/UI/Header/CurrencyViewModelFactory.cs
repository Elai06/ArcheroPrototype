using _Project.Scripts.Gameplay.Models.Currency;
using Infrastructure.Windows.MVVM;

namespace _Project.Scripts.Gameplay.UI.Header
{
    public class CurrencyViewModelFactory : IViewModelFactory<CurrencyViewModel,CurrenciesView, ICurrenciesModel>
    {
        public CurrencyViewModel Create(ICurrenciesModel model, CurrenciesView view) => new CurrencyViewModel( model, view);

    }
}
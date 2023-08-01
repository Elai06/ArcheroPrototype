using _Project.Scripts.Gameplay.Models.Currency;
using Infrastructure.Windows;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.UI.Header
{
    public class UpperPanelWindow : Window
    {
        [SerializeField] private CurrencyViewInitializer currencyViewInitializer;

        private ICurrenciesModel _currenciesModel;

        [Inject]
        public void Construct(ICurrenciesModel currenciesModel)
        {
            _currenciesModel = currenciesModel;
        }

        private void OnEnable()
        {
            currencyViewInitializer.Initialize(_currenciesModel);
        }
    }
}
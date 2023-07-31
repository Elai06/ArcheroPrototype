using Infrastructure.Windows.MVVM;
using UnityEngine;
using Zenject;

namespace SirGames.Scripts.Windows.MVVM
{
    public abstract class ViewInitializer<TViewModel, TView, TModel> : MonoBehaviour
        where TViewModel : IViewModel
    {
        [SerializeField] private TView _view;

        private IViewModelFactory<TViewModel, TView, TModel> _viewModelFactory;
        private TViewModel _viewModel;

        [Inject]
        private void Construct(IViewModelFactory<TViewModel, TView, TModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void Initialize(TModel model)
        {
            _viewModel = _viewModelFactory.Create(model, _view);
            _viewModel?.Initialize();
            _viewModel?.Subscribe();
        }

        private void OnDisable() =>
            _viewModel?.Unsubscribe();
    }
}
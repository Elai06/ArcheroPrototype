using System.Collections.Generic;
using UnityEngine;
using Utils.ZenjectInstantiateUtil;
using Zenject;

namespace Infrastructure.Windows.MVVM
{
    public class CompositeView<TCompositeModel, TViewModel, TModel, TView> : MonoBehaviour
        where TCompositeModel : ICompositeModel<TModel>
        where TViewModel : IViewModel
        where TView : MonoBehaviour
    {
        public TView Prefab;

        private TCompositeModel _compositeModel;
        private IInstantiateSpawner _instantiateSpawner;
        private IViewModelFactory<TViewModel, TView, TModel> _viewModelFactory;

        private readonly Dictionary<TModel, TViewModel> _viewModels = new Dictionary<TModel, TViewModel>();

        [Inject]
        private void Construct(TCompositeModel compositeModel, IInstantiateSpawner instantiateSpawner,
            IViewModelFactory<TViewModel, TView, TModel> viewModelFactory)
        {
            _instantiateSpawner = instantiateSpawner;
            _compositeModel = compositeModel;
            _viewModelFactory = viewModelFactory;
        }

        private void Awake()
        {
            foreach(var model in _compositeModel.Models)
                CreateView(model);
        }

        private void Start()
        {
            foreach(var viewModel in _viewModels.Values)
                viewModel.Initialize();
        }

        private void OnEnable() =>
            Subscribe();

        private void OnDisable() =>
            Unsubscribe();
        
        private void CreateView(TModel model)
        {
            var view = _instantiateSpawner.Instantiate<TView>(Prefab, transform);
            var viewModel = _viewModelFactory.Create(model, view);
            _viewModels.Add(model, viewModel);
        }

        private void OnRemoveModel(TModel model)
        {
            var viewModel = _viewModels[model];
            viewModel.Cleanup();
            _viewModels.Remove(model);
        }

        private void Subscribe()
        {
            if(_compositeModel is IExtendedCompositeModel<TModel> extendedCompositeModel)
            {
                extendedCompositeModel.ModelAdded += CreateView;
                extendedCompositeModel.ModelRemoved += OnRemoveModel;
            }

            foreach(var viewModel in _viewModels.Values)
                viewModel.Subscribe();
        }

        private void Unsubscribe()
        {
            if(_compositeModel is IExtendedCompositeModel<TModel> extendedCompositeModel)
            {
                extendedCompositeModel.ModelAdded -= CreateView;
                extendedCompositeModel.ModelRemoved -= OnRemoveModel;
            }

            foreach(var currencyViewModel in _viewModels.Values)
                currencyViewModel.Unsubscribe();
        }
    }
}
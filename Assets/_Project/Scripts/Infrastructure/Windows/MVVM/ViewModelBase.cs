using System.Threading.Tasks;
using _Project.Scripts.Infrastructure.Windows.MVVM;
using UnityEngine;

namespace Infrastructure.Windows.MVVM
{
    public abstract class ViewModelBase<TModel, TView> : IViewModel where TView : MonoBehaviour
    {
        protected readonly TModel Model;
        protected readonly TView View;

        protected ViewModelBase(TModel model, TView view)
        {
            Model = model;
            View = view;
        }

        public abstract Task Show();

        protected virtual void OnClicked() { }

        public virtual async Task Initialize() =>
            await Show();

        public virtual void Subscribe()
        {
            if(View is IInteractableView interactableView)
                interactableView.Clicked += OnClicked;
        }

        public virtual void Unsubscribe()
        {
            if(View is IInteractableView interactableView)
                interactableView.Clicked -= OnClicked;
        }

        public virtual void Cleanup() => 
            Object.Destroy(View.gameObject);
    }
}
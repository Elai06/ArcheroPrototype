namespace Infrastructure.Windows.MVVM
{
    public interface IViewModelFactory<out TViewModel, in TView, in TModel>
        where TViewModel : IViewModel
    {
        TViewModel Create(TModel model, TView view);
    }
}
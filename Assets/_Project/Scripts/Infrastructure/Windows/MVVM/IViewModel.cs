using System.Threading.Tasks;

namespace Infrastructure.Windows.MVVM
{
    public interface IViewModel
    {
        Task Initialize();
        void Subscribe();
        void Unsubscribe();
        void Cleanup();
        Task Show();
    }
}
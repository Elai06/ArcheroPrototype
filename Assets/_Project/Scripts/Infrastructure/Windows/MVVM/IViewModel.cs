using System.Threading.Tasks;

namespace _Project.Scripts.Infrastructure.Windows.MVVM
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
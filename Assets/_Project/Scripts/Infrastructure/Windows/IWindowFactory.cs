using System.Threading.Tasks;

namespace Infrastructure.Windows
{
    public interface IWindowFactory
    {
        Task<Window> Create(WindowType windowType);
    }
}
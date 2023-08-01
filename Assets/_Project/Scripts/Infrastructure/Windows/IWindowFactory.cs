using _Project.Scripts.Infrastructure.Windows;

namespace Infrastructure.Windows
{
    public interface IWindowFactory
    {
        Window Create(WindowType windowType);
    }
}
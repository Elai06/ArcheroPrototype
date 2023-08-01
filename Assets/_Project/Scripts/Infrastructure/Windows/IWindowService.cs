using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Scripts.Infrastructure.Windows;

namespace Infrastructure.Windows
{
    public interface IWindowService
    {
        Window Open(WindowType windowType);
        void Close(WindowType windowType);
        Window Open<TPaylaod>(WindowType windowType, TPaylaod paylaod);
        Dictionary<WindowType, Window> CashedWindows { get; }
        bool IsOpen(WindowType tutorial);
        event Action<WindowType> OnClosed;
        event Action<WindowType> OnOpen;
    }
}
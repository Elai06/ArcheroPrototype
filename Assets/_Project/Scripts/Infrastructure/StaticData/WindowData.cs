using System;
using _Project.Scripts.Infrastructure.Windows;
using Infrastructure.Windows;
using MVVMLibrary.Enums;

namespace _Project.Scripts.Infrastructure.StaticData
{
    [Serializable]
    public class WindowData
    {
        public WindowType WindowType;
        public Layer Layer;
        public Window Window;
    }
}
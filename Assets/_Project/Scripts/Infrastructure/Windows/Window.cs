using _Project.Scripts.Infrastructure.Windows;
using MVVMLibrary.Enums;
using UnityEngine;

namespace Infrastructure.Windows
{
    public class Window : MonoBehaviour
    {
        public Layer Layer { get; private set; }
        public WindowType WindowType { get; private set; }

        public void SetLayer(Layer layer)
        {
            Layer = layer;
        }
        
        public void SetType(WindowType windowType)
        {
            WindowType = windowType;
        }
    }
}
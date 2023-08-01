using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Scripts.Infrastructure.Windows;
using MVVMLibrary.Enums;
using UnityEngine;

namespace Infrastructure.Windows
{
    public class WindowService : IWindowService
    {
        public event Action<WindowType> OnClosed;
        public event Action<WindowType> OnOpen;

        private readonly Dictionary<WindowType, Window> _cashedWindows = new Dictionary<WindowType, Window>();
        private readonly Dictionary<Layer, Window> _windowsOnLayer = new Dictionary<Layer, Window>();
        private readonly IWindowFactory _windowFactory;

        public WindowService(IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
        }

        public Dictionary<WindowType, Window> CashedWindows => _cashedWindows;

        public bool IsOpen(WindowType type)
        {
            if (_cashedWindows.TryGetValue(type, out var window))
            {
                return window.gameObject.activeSelf;
            }

            return false;
        }

        public Window Open(WindowType windowType)
        {
            OnOpen?.Invoke(windowType);

            if (_cashedWindows.TryGetValue(windowType, out var window))
            {
                window.gameObject.SetActive(true);
                CloseWindowOnSameLayer(window);
                return window;
            }

            var windowInstance = _windowFactory.Create(windowType);
            windowInstance.SetType(windowType);

            if (_cashedWindows.ContainsKey(windowType))
            {
                Debug.LogWarning($"This screen already exists");
                return null;
            }

            _cashedWindows.Add(windowType, windowInstance);
            CloseWindowOnSameLayer(windowInstance);

            return windowInstance;
        }


        private void CloseWindowOnSameLayer(Window window)
        {
            if (_windowsOnLayer.TryGetValue(window.Layer, out var openedWindow))
                if (window != openedWindow)
                    Close(openedWindow.WindowType);

            _windowsOnLayer[window.Layer] = window;
        }

        public Window Open<TPaylaod>(WindowType windowType, TPaylaod paylaod)
        {
            var window = Open(windowType);
            if (window is PayloadWindow<TPaylaod> payloadWindow)
                payloadWindow.OnOpen(paylaod);

            return window;
        }

        public void Close(WindowType windowType)
        {
            if (_cashedWindows.TryGetValue(windowType, out var window))
            {
                window.gameObject.SetActive(false);
                OnClosed?.Invoke(windowType);
            }
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Windows;
using MVVMLibrary.Enums;
using SirGames.Scripts.Infrastructure.Windows;
using SirGames.Scripts.StaticData;
using UnityEngine;
using Utils.ZenjectInstantiateUtil;

namespace SirGames.Scripts.Windows
{
    public class WindowFactory : IWindowFactory
    {
        private readonly IStaticDataService _staticDataService;

        private readonly Dictionary<Layer, Canvas> _layers;
        private readonly IInstantiateSpawner _inject;

        public WindowFactory(IStaticDataService staticDataService,
            LayersContainer layersContainer, IInstantiateSpawner inject)
        {
            _staticDataService = staticDataService;
            _inject = inject;
            _layers = new Dictionary<Layer, Canvas>();
            foreach (var canvasLayerEntry in layersContainer.CanvasLayerEntry)
            {
                _layers.Add(canvasLayerEntry.Layer, canvasLayerEntry.Canvas);
            }
        }

        public async Task<Window> Create(WindowType windowType)
        {
            var windowStaticData = _staticDataService.GetWindowData(windowType);
            var parent = _layers[windowStaticData.Layer].transform;
            var prefab = windowStaticData.Window;
            var windowInstance = _inject.Instantiate<Window>(prefab, parent);
            windowInstance.SetLayer(windowStaticData.Layer);
            return windowInstance;
        }
    }
}
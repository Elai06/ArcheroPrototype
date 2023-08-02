using Infrastructure.Windows;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.UI.Inventory.Guns
{
    public class GunsInventoryWindow : Window
    {
        [SerializeField] private GunsInventoryViewInitializer _gunsInventoryViewInitializer;

        private IGunsInventoryModel _gunsInventory;
        
        [Inject]
        public void Construct(IGunsInventoryModel gunsInventoryModel)
        {
            _gunsInventory = gunsInventoryModel;
        }

        private void OnEnable()
        {
             _gunsInventoryViewInitializer.Initialize(_gunsInventory);
        }
    }
}
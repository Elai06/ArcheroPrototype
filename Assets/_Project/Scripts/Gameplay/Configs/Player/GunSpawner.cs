using System;
using _Project.Scripts.Gameplay.Configs.Guns;
using _Project.Scripts.Gameplay.UI.Inventory.Guns;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.Configs.Player
{
    public class GunSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _gunPosition;
        [SerializeField] private Gameplay.Player.Player _player;

        private Gun _gunSpawned;

        private IGunsInventoryModel _gunsInventory;

        [Inject]
        public void Construct(IGunsInventoryModel gunsInventory)
        {
            _gunsInventory = gunsInventory;
        }

        private void OnEnable()
        {
            _gunsInventory.OnEquipped += Equipped;
        }

        private void OnDisable()
        {
            _gunsInventory.OnEquipped -= Equipped;
        }

        private void Equipped()
        {
            Destroy(_gunSpawned.gameObject);

            SpawnGun();
        }

        public void SpawnGun()
        {
            var gun = _gunsInventory.GetEquippedGun();
            _gunSpawned = Instantiate(gun.Gun, _gunPosition.position, Quaternion.identity, _player.GunPosition);
        }

        public Gun GetEquippedGun()
        {
            return _gunSpawned;
        }
    }
}
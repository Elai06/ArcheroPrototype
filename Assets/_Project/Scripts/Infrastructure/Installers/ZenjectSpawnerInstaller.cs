using UnityEngine;
using Utils.ZenjectInstantiateUtil;
using Zenject;

namespace Infrastructure.Installers
{
    public class ZenjectSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private GameObjectDestroyer _gameObjectDestroyer;
        
        public override void InstallBindings()
        {
            var spawner = new ZenjectInstantiateSpawner(Container);
            InjectService.Instance.SetInjectSpawner(spawner);

            Container
                .Bind<IInstantiateSpawner>()
                .To<ZenjectInstantiateSpawner>()
                .FromInstance(spawner);

            Container
                .Bind<IInjector>()
                .To<ZenjectInstantiateSpawner>()
                .FromInstance(spawner);

            Container
                .Bind<IGameObjectFactory>()
                .To<ZenjectInstantiateSpawner>()
                .FromInstance(spawner);

            Container
                .Bind<IGameObjectDestroyer>()
                .To<GameObjectDestroyer>()
                .FromInstance(_gameObjectDestroyer);
        }
    }
}
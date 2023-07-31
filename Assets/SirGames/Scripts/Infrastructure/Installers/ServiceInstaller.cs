using Infrastructure.PersistenceProgress;
using Infrastructure.SaveLoads;
using Infrastructure.SceneManagement;
using Infrastructure.StateMachine.Sates;
using Infrastructure.StaticData;
using Infrastructure.UnityBehaviours;
using Infrastructure.Windows;
using SirGames.Scripts.Infrastructure.StateMachine;
using SirGames.Scripts.Infrastructure.StateMachine.Sates;
using SirGames.Scripts.Infrastructure.Windows;
using SirGames.Scripts.SaveLoads;
using SirGames.Scripts.StaticData;
using SirGames.Scripts.Windows;
using UnityEngine;
using Zenject;

namespace SirGames.Scripts.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineService coroutineService;
        [SerializeField] private LayersContainer _layersContainer;

        public override void InstallBindings()
        {
            BindGameStates();
            BindInfrastructureServices();
            BindModels();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IProgressService>().To<PlayerProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<ICoroutineService>().FromInstance(coroutineService).AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
            Container.Bind<LayersContainer>().FromInstance(_layersContainer).AsSingle();
        }

        private void BindModels()
        {
        }

        private void BindGameStates()
        {
            Container.Bind<IStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<ExitState>().AsSingle();
            Container.Bind<GameState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
        }
    }
}
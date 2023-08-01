using _Project.Scripts.Gameplay.Configs.Player;
using _Project.Scripts.Gameplay.Models.Currency;
using _Project.Scripts.Gameplay.UI.Header;
using _Project.Scripts.Gameplay.UI.Pause;
using _Project.Scripts.Infrastructure.PersistenceProgress;
using _Project.Scripts.Infrastructure.SaveLoads;
using _Project.Scripts.Infrastructure.StateMachine;
using _Project.Scripts.Infrastructure.StateMachine.States;
using _Project.Scripts.Infrastructure.StaticData;
using Infrastructure.SaveLoads;
using Infrastructure.SceneManagement;
using Infrastructure.StateMachine.Sates;
using Infrastructure.UnityBehaviours;
using Infrastructure.Windows;
using SirGames.Scripts.Infrastructure.StateMachine;
using SirGames.Scripts.Infrastructure.Windows;
using SirGames.Scripts.Windows;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineService _coroutineService;
        [SerializeField] private LayersContainer _layersContainer;
        [SerializeField] private GameStaticData _gameStaticData;
        [SerializeField] private EnemySpawner _enemySpawner;

        public override void InstallBindings()
        {
            BindViewModelFactory();
            BindGameStates();
            BindInfrastructureServices();
            BindModels();
        }

        private void BindViewModelFactory()
        {
            Container.BindInterfacesAndSelfTo<CurrencyViewModelFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<PauseViewModelFactory>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<IStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<ExitState>().AsSingle();
            Container.Bind<GameState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<IProgressService>().To<PlayerProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();

            Container.Bind<LayersContainer>().FromInstance(_layersContainer).AsSingle();
            Container.Bind<GameStaticData>().FromInstance(_gameStaticData).AsSingle();
            Container.Bind<ICoroutineService>().FromInstance(_coroutineService).AsSingle();
        }

        private void BindModels()
        {
            Container.BindInterfacesAndSelfTo<PauseModel>().AsSingle();
            Container.Bind<ICurrenciesModel>().To<CurrenciesModel>().AsSingle();
            Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle();
        }
    }
}
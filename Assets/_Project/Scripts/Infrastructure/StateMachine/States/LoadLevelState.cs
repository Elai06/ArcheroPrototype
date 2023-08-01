using _Project.Scripts.Gameplay.Models.Currency;
using Infrastructure.SceneManagement;
using Infrastructure.StateMachine.Sates;
using SirGames.Scripts.Infrastructure.StateMachine;

namespace _Project.Scripts.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IState
    {
        private const string Scene = "Gameplay";

        private IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        
        public LoadLevelState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(Scene, OnLoaded);
        }

        public void Initialize(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<GameState>();
        }

        public void Exit()
        {
        }
        
    }
}
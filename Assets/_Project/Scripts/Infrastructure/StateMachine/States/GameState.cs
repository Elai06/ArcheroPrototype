using _Project.Scripts.Infrastructure.Windows;
using Infrastructure.StateMachine.Sates;
using Infrastructure.Windows;
using SirGames.Scripts.Infrastructure.StateMachine;

namespace _Project.Scripts.Infrastructure.StateMachine.States
{
    public class GameState : IState
    {
        private readonly IWindowService _windowService;
        private IStateMachine _stateMachine;

        public GameState(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Initialize(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _windowService.Open(WindowType.UpperPanel);
        }

        public void Exit()
        {
        }
    }
}
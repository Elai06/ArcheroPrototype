using Infrastructure.Windows;
using SirGames.Scripts.Infrastructure.StateMachine;

namespace Infrastructure.StateMachine.Sates
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
            _windowService.Open(WindowType.Menu);
        }

        public void Exit()
        {
        }
    }
}
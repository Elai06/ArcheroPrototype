using Infrastructure.StateMachine.Sates;

namespace SirGames.Scripts.Infrastructure.StateMachine.Sates
{
    public class BootstrapState : IState
    {
        private IStateMachine _stateMachine;

        public void Initialize(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            InitializeDependencies();
            
            _stateMachine.Enter<LoadLevelState>();
        }


        private void InitializeDependencies()
        {
        }
    }
}
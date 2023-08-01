using Infrastructure.SaveLoads;
using Infrastructure.StateMachine.Sates;
using SirGames.Scripts.Infrastructure.StateMachine;

namespace _Project.Scripts.Infrastructure.StateMachine.States
{
    public class ExitState : IState
    {
        private readonly ISaveLoadService _saveLoadService;

        public ExitState(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void Initialize(IStateMachine stateMachine)
        {
        }

        public void Enter()
        {
            _saveLoadService.Save();
        }

        public void Exit()
        {
        }
    }
}
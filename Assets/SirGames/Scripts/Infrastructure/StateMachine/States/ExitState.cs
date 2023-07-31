

using Infrastructure.SaveLoads;
using SirGames.Scripts.Infrastructure.StateMachine;

namespace Infrastructure.StateMachine.Sates
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
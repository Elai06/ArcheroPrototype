using _Project.Scripts.Infrastructure.StateMachine.States;
using Infrastructure.StateMachine.Sates;

namespace _Project.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : SirGames.Scripts.Infrastructure.StateMachine.StateMachine
    {
        public GameStateMachine(ExitState exitState, GameState gameState, LoadLevelState loadLevelState, BootstrapState bootstrapState)
        {
            AddState(exitState);
            AddState(gameState);
            AddState(bootstrapState);
            AddState(loadLevelState);
        }
    }
}
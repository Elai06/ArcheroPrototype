using Infrastructure.StateMachine.Sates;
using SirGames.Scripts.Infrastructure.StateMachine.Sates;

namespace SirGames.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : StateMachine
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
using SirGames.Scripts.Infrastructure.StateMachine;

namespace Infrastructure.StateMachine.Sates
{
    public interface IState: IExitableState
    {
        void Enter();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
  
    public interface IExitableState
    {
        void Initialize(IStateMachine stateMachine);
        void Exit();
    }
}
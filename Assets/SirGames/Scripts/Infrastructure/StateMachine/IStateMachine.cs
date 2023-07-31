using Infrastructure.StateMachine.Sates;

namespace SirGames.Scripts.Infrastructure.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}
using System;
using System.Collections.Generic;
using Infrastructure.StateMachine.Sates;

namespace SirGames.Scripts.Infrastructure.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new Dictionary<Type, IExitableState>();
        private IExitableState _activeState;

        public event Action OnStateChange;
        public IExitableState CurrentState => _activeState;
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
            OnStateChange?.Invoke();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
            OnStateChange?.Invoke();
        }

        public void AddState<TState>(TState state) where TState : IExitableState
        {
            _states[typeof(TState)] = state;
            state.Initialize(this);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            var state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
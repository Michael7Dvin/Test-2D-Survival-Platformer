using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StateMachine.States;

namespace CodeBase.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();

        private IExitableState _activeState;

        public IExitableState ActiveState => _activeState;

        public void EnterState<TState>() where TState : IState
        {
            _activeState?.Exit();

            if (_states[typeof(TState)] is TState state)
            {
                _activeState = state;
                
                state.Enter();
            }
        }

        public void EnterState<TState, TArgs>(TArgs args) where TState : IStateWithArgument<TArgs>
        {
            _activeState?.Exit();

            if (_states[typeof(TState)] is TState state) 
                state.Enter(args);
        }

        public void AddState<TState>(TState state) where TState : IExitableState => 
            _states.Add(typeof(TState), state);
    }
}
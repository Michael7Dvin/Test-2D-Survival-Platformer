using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class InitializationState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public InitializationState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("InitializationState");
            _gameStateMachine.EnterState<LevelLoadingState>();
        }

        public void Exit()
        {
        }
    }
}
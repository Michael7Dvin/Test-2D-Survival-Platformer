using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class LevelLoadingState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public LevelLoadingState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("LevelLoadingState");
            _gameStateMachine.EnterState<GameplayState>();
        }

        public void Exit()
        {
            
        }
    }
}
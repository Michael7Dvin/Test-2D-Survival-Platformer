using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameplayState : IState
    {
        public void Enter()
        {
            Debug.Log("GameplayState");
        }

        public void Exit()
        {
        }
    }
}
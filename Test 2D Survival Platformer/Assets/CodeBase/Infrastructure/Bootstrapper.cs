using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class Bootstrapper : IInitializable
    {
        private readonly IGameStateMachine _stateMachine;

        public Bootstrapper(IGameStateMachine stateMachine,
            InitializationState initializationState,
            LevelLoadingState levelLoadingState,
            GameplayState gameplayState)
        {
            _stateMachine = stateMachine;

            _stateMachine.AddState(initializationState);
            _stateMachine.AddState(levelLoadingState);
            _stateMachine.AddState(gameplayState);
        }

        public void Initialize()
        {
            _stateMachine.EnterState<InitializationState>();
        }
    }
}
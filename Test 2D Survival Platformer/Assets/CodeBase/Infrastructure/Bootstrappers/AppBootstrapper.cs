using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using Zenject;

namespace CodeBase.Infrastructure.Bootstrappers
{
    public class AppBootstrapper : IInitializable
    {
        private readonly IGameStateMachine _stateMachine;

        public AppBootstrapper(IGameStateMachine stateMachine,
            InitializationState initializationState,
            SceneLoadingState sceneLoadingState)
        {
            _stateMachine = stateMachine;

            _stateMachine.AddState(initializationState);
            _stateMachine.AddState(sceneLoadingState);
        }

        public void Initialize() => 
            _stateMachine.EnterState<InitializationState>();
    }
}
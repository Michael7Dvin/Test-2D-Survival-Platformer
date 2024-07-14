using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using Zenject;

namespace CodeBase.Infrastructure.Bootstrappers
{
    public class LevelBootstrapper : IInitializable
    {
        private readonly IGameStateMachine _stateMachine;

        public LevelBootstrapper(IGameStateMachine stateMachine,
            WorldSpawningState worldSpawningState,
            GameplayState gameplayState,
            RestartState restartState)
        {
            _stateMachine = stateMachine;

            _stateMachine.AddState(worldSpawningState);
            _stateMachine.AddState(gameplayState);
            _stateMachine.AddState(restartState);
        }

        public void Initialize() => 
            _stateMachine.EnterState<WorldSpawningState>();
    }
}
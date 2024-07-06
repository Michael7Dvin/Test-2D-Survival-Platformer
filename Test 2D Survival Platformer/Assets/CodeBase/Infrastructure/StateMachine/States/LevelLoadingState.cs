using CodeBase.Infrastructure.Services.SceneLoader;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class LevelLoadingState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LevelLoadingState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            await _sceneLoader.LoadGameLevel();
            _gameStateMachine.EnterState<GameplayState>();
        }

        public void Exit()
        {
            
        }
    }
}
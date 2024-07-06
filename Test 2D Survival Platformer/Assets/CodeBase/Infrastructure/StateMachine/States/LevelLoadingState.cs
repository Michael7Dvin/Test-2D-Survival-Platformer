using CodeBase.Infrastructure.Services.CharacterFactory;
using CodeBase.Infrastructure.Services.SceneLoader;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class LevelLoadingState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICharacterFactory _characterFactory;

        public LevelLoadingState(IGameStateMachine gameStateMachine,
            ISceneLoader sceneLoader,
            ICharacterFactory characterFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _characterFactory = characterFactory;
        }

        public async void Enter()
        {
            await _sceneLoader.LoadGameLevel();
            await _characterFactory.WarmUp();
            await _characterFactory.Create();
            _gameStateMachine.EnterState<GameplayState>();
        }

        public void Exit()
        {
            
        }
    }
}
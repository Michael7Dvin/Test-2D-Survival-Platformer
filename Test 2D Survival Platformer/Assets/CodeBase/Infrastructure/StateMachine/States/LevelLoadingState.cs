using CodeBase.Gameplay.Character;
using CodeBase.Infrastructure.Services.CharacterFactory;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.UI.Services;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class LevelLoadingState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICharacterFactory _characterFactory;
        private readonly IUIFactory _uiFactory;

        public LevelLoadingState(IGameStateMachine gameStateMachine,
            ISceneLoader sceneLoader,
            ICharacterFactory characterFactory,
            IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _characterFactory = characterFactory;
            _uiFactory = uiFactory;
        }

        public async void Enter()
        {
            await _sceneLoader.LoadGameLevel();
            await _characterFactory.WarmUp();
            Character character = await _characterFactory.Create();

            await _uiFactory.WarmUp();
            await _uiFactory.CreateCanvas();
            await _uiFactory.CreateEventSystem();
            await _uiFactory.CreateCharacterHealthView(character.Health);
            
            _gameStateMachine.EnterState<GameplayState>();
        }

        public void Exit()
        {
            
        }
    }
}
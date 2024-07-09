﻿using CodeBase.Gameplay.Character;
using CodeBase.Infrastructure.Services.CameraFactory;
using CodeBase.Infrastructure.Services.CharacterFactory;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.UI.Services;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class LevelLoadingState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICharacterFactory _characterFactory;
        private readonly IUIFactory _uiFactory;
        private readonly ICameraFactory _cameraFactory;

        public LevelLoadingState(IGameStateMachine gameStateMachine,
            ISceneLoader sceneLoader,
            ICharacterFactory characterFactory,
            IUIFactory uiFactory,
            ICameraFactory cameraFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _characterFactory = characterFactory;
            _uiFactory = uiFactory;
            _cameraFactory = cameraFactory;
        }

        public async void Enter()
        {
            await _sceneLoader.LoadGameLevel();
            await _characterFactory.WarmUp();
            Character character = await _characterFactory.Create();

            await _cameraFactory.WarmUp();
            await _cameraFactory.Create(character.transform);
            
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
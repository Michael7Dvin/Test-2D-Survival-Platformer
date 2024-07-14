using CodeBase.Gameplay.Character;
using CodeBase.Infrastructure.Factories.CameraFactory;
using CodeBase.Infrastructure.Factories.CharacterFactory;
using CodeBase.Infrastructure.Services.CameraProvider;
using CodeBase.Infrastructure.Services.CharacterProvider;
using CodeBase.Infrastructure.Services.ProjectilePool;
using CodeBase.Infrastructure.StateMachine.States.Base;
using CodeBase.UI.Services.UIFactory;
using CodeBase.UI.Services.WindowService;
using CodeBase.UI.Windows;
using CodeBase.UI.Windows.DeathWindow;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class WorldSpawningState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        
        private readonly ICharacterFactory _characterFactory;
        private readonly IUIFactory _uiFactory;
        private readonly ICameraFactory _cameraFactory;
        private readonly IWindowService _windowService;
        private readonly ICharacterProvider _characterProvider;
        private readonly ICameraProvider _cameraProvider;
        private readonly IProjectilePool _projectilePool;

        public WorldSpawningState(IGameStateMachine gameStateMachine,
            ICharacterFactory characterFactory,
            IUIFactory uiFactory,
            ICameraFactory cameraFactory,
            IWindowService windowService,
            ICharacterProvider characterProvider,
            ICameraProvider cameraProvider,
            IProjectilePool projectilePool)
        {
            _gameStateMachine = gameStateMachine;
            _characterFactory = characterFactory;
            _uiFactory = uiFactory;
            _cameraFactory = cameraFactory;
            _windowService = windowService;
            _characterProvider = characterProvider;
            _cameraProvider = cameraProvider;
            _projectilePool = projectilePool;
        }

        public async void Enter()
        {
            await _characterFactory.WarmUp();
            ICharacter character = await _characterFactory.Create();
            _characterProvider.Set(character);
            
            await _cameraFactory.WarmUp();
            Camera camera = await _cameraFactory.Create(character.GameObject.transform);
            _cameraProvider.Set(camera);
            
            await _uiFactory.WarmUp();
            await _uiFactory.CreateCanvas();
            await _uiFactory.CreateEventSystem();
            await _uiFactory.CreateCharacterHealthView(character.Health);
            
            DeathWindowView deathWindowView = await _uiFactory.CreateDeathWindow();
            _windowService.RegisterWindow(WindowID.DeathWindow, deathWindowView);
            
            await _projectilePool.Initialize(6);
            
            _gameStateMachine.EnterState<GameplayState>();        
        }

        public void Exit()
        {
        }
    }
}
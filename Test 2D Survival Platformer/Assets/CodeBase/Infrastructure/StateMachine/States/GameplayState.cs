using System;
using CodeBase.Gameplay.Character;
using CodeBase.Gameplay.Services.ProjectilesSpawner;
using CodeBase.Infrastructure.Services.CameraProvider;
using CodeBase.Infrastructure.Services.CharacterProvider;
using CodeBase.Infrastructure.StateMachine.States.Base;
using CodeBase.UI.Services.WindowService;
using CodeBase.UI.Windows;
using UniRx;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameplayState : IState, IDisposable
    {
        private readonly ICharacterProvider _characterProvider;
        private readonly IWindowService _windowService;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly ICameraProvider _cameraProvider;
        private readonly IProjectilesSpawner _projectilesSpawner;

        public GameplayState(ICharacterProvider characterProvider,
            IWindowService windowService,
            ICameraProvider cameraProvider,
            IProjectilesSpawner projectilesSpawner)
        {
            _characterProvider = characterProvider;
            _windowService = windowService;
            _cameraProvider = cameraProvider;
            _projectilesSpawner = projectilesSpawner;
        }

        public void Enter()
        {
            ICharacter character = _characterProvider.Get();
            Camera camera = _cameraProvider.Get();
            
            character.Dieable.IsDead
                .Where(isDead => isDead == true)
                .Subscribe(_ => _windowService.ShowWindow(WindowID.DeathWindow))
                .AddTo(_compositeDisposable);

            character.Mover.Enabled = true;

            _projectilesSpawner.Enable(camera, character);
        }

        public void Exit()
        {
            _projectilesSpawner.Disable();
            _compositeDisposable.Clear();
        }

        public void Dispose() => 
            _compositeDisposable?.Dispose();
    }
}
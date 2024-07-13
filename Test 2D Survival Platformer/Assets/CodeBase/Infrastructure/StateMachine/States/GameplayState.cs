using System;
using CodeBase.Gameplay.Character;
using CodeBase.Gameplay.Services.ProjectilesSpawner;
using CodeBase.Infrastructure.Services.CameraProvider;
using CodeBase.Infrastructure.Services.CharacterProvider;
using CodeBase.Infrastructure.Services.ProjectilePool;
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
        private readonly IProjectilePool _projectilePool;
        private readonly IProjectilesSpawner _projectilesSpawner;

        public GameplayState(ICharacterProvider characterProvider,
            IWindowService windowService,
            ICameraProvider cameraProvider,
            IProjectilePool projectilePool,
            IProjectilesSpawner projectilesSpawner)
        {
            _characterProvider = characterProvider;
            _windowService = windowService;
            _cameraProvider = cameraProvider;
            _projectilePool = projectilePool;
            _projectilesSpawner = projectilesSpawner;
        }

        public async void Enter()
        {
            ICharacter character = _characterProvider.Get();
            Camera camera = _cameraProvider.Get();
            
            character.Dieable.IsDead
                .Where(isDead => isDead == true)
                .Subscribe(_ => _windowService.ShowWindow(WindowID.DeathWindow))
                .AddTo(_compositeDisposable);

            character.Mover.Enabled = true;

            await _projectilePool.Initialize(6);
            _projectilesSpawner.Initialize(camera, character);
        }

        public void Exit()
        {
            _compositeDisposable.Clear();
        }

        public void Dispose() => 
            _compositeDisposable?.Dispose();
    }
}
using System;
using CodeBase.Gameplay.Character;
using CodeBase.Infrastructure.Services.CharacterProvider;
using CodeBase.Infrastructure.StateMachine.States.Base;
using CodeBase.UI.Services.WindowService;
using CodeBase.UI.Windows;
using UniRx;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameplayState : IState, IDisposable
    {
        private readonly ICharacterProvider _characterProvider;
        private readonly IWindowService _windowService;
        private readonly CompositeDisposable _compositeDisposable = new();

        public GameplayState(ICharacterProvider characterProvider, IWindowService windowService)
        {
            _characterProvider = characterProvider;
            _windowService = windowService;
        }

        public void Enter()
        {
            ICharacter character = _characterProvider.Get();
            
            character.Dieable.IsDead
                .Where(isDead => isDead == true)
                .Subscribe(_ => _windowService.ShowWindow(WindowID.DeathWindow))
                .AddTo(_compositeDisposable);

            character.Mover.Enabled = true;
        }

        public void Exit() => 
            _compositeDisposable.Clear();

        public void Dispose() => 
            _compositeDisposable?.Dispose();
    }
}
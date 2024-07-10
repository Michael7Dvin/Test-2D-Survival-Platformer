using System;
using CodeBase.Gameplay.Character;
using CodeBase.UI.Services.WindowService;
using CodeBase.UI.Windows;
using UniRx;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameplayState : IStateWithArgument<ICharacter>, IDisposable
    {
        private readonly IWindowService _windowService;
        private readonly CompositeDisposable _compositeDisposable = new();

        public GameplayState(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Enter(ICharacter character)
        {
            character.Dieable.Died
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
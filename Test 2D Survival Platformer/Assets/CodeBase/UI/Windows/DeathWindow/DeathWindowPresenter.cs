using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.UI.Services.WindowService;

namespace CodeBase.UI.Windows.DeathWindow
{
    public class DeathWindowPresenter
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IWindowService _windowService;

        public DeathWindowPresenter(IGameStateMachine gameStateMachine, IWindowService windowService)
        {
            _gameStateMachine = gameStateMachine;
            _windowService = windowService;
        }

        public void Restart()
        {
            _windowService.HideWindow(WindowID.DeathWindow);
            _gameStateMachine.EnterState<RestartState>();
        }
    }
}
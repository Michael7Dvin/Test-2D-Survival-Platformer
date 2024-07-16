using CodeBase.Infrastructure.StateMachine.States.Base;
using CodeBase.UI.Services.LoadingScreen;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine.AddressableAssets;
using UnityEngine.Device;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class InitializationState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ILoadingScreenService _loadingScreenService;

        public InitializationState(IGameStateMachine gameStateMachine, ILoadingScreenService loadingScreenService)
        {
            _gameStateMachine = gameStateMachine;
            _loadingScreenService = loadingScreenService;
        }

        public async void Enter()
        {
            await _loadingScreenService.Initialize();
            
            Application.targetFrameRate = 60;
            
            await Addressables.InitializeAsync();
            DOTween.Init();
            
            _gameStateMachine.EnterState<SceneLoadingState>();
        }

        public void Exit()
        {
        }
    }
}
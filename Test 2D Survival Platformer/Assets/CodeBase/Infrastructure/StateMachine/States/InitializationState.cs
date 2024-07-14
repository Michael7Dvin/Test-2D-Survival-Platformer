using CodeBase.Infrastructure.StateMachine.States.Base;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine.AddressableAssets;
using UnityEngine.Device;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class InitializationState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public InitializationState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public async void Enter()
        {
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
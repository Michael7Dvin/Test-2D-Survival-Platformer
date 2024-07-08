using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine.AddressableAssets;

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
            await Addressables.InitializeAsync();
            DOTween.Init();
            
            _gameStateMachine.EnterState<LevelLoadingState>();
        }

        public void Exit()
        {
        }
    }
}
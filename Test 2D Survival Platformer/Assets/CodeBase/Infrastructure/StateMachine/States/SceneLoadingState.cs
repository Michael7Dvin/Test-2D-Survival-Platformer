using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.StateMachine.States.Base;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class SceneLoadingState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public SceneLoadingState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            await _sceneLoader.LoadGameLevel();
        }

        public void Exit()
        {
        }
    }
}
using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneAddresses _sceneAddresses;
        
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindServices();
        }

        private void BindServices()
        {
            Container.Bind<IStaticDataProvider>()
                .To<StaticDataProvider>()
                .AsSingle()
                .WithArguments(_sceneAddresses);

            Container.Bind<IAddressablesLoader>().To<AddressablesLoader>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<InitializationState>().AsSingle();
            Container.Bind<LevelLoadingState>().AsSingle();
            Container.Bind<GameplayState>().AsSingle();
        }
    }
}
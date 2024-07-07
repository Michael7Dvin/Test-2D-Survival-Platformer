using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.CharacterFactory;
using CodeBase.Infrastructure.Services.InputService;
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
        [SerializeField] private PrefabAddresses _prefabAddresses;
        [SerializeField] private CharacterConfig _characterConfig;
        
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
                .WithArguments(_sceneAddresses, _prefabAddresses, _characterConfig);

            Container.Bind<IAddressablesLoader>().To<AddressablesLoader>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
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
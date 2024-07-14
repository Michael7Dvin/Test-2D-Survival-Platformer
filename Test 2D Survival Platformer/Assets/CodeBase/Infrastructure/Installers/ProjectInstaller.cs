using CodeBase.Gameplay.Services.ProjectilesSpawner;
using CodeBase.Infrastructure.Factories.CameraFactory;
using CodeBase.Infrastructure.Factories.CharacterFactory;
using CodeBase.Infrastructure.Factories.ProjectileFactory;
using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.CameraProvider;
using CodeBase.Infrastructure.Services.CharacterProvider;
using CodeBase.Infrastructure.Services.InputService;
using CodeBase.Infrastructure.Services.ProjectilePool;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.StaticData;
using CodeBase.UI.Services.UIFactory;
using CodeBase.UI.Services.WindowService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneAddresses _sceneAddresses;
        [SerializeField] private PrefabAddresses _prefabAddresses;
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private ProjectileConfig _projectileConfig; 
        [SerializeField] private ProjectileSpawnerConfig _projectileSpawnerConfig;
        
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
                .WithArguments(_sceneAddresses,
                    _prefabAddresses,
                    _characterConfig,
                    _projectileConfig,
                    _projectileSpawnerConfig);

            Container.Bind<IAddressablesLoader>().To<AddressablesLoader>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            
            Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();

            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            
            Container.Bind<ICharacterProvider>().To<CharacterProvider>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            
            Container.Bind<IProjectilesSpawner>().To<ProjectilesSpawner>().AsSingle();
            Container.Bind<IProjectilePool>().To<ProjectilePool>().AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<InitializationState>().AsSingle();
            Container.Bind<LevelLoadingState>().AsSingle();
            Container.Bind<GameplayState>().AsSingle();
            Container.Bind<RestartState>().AsSingle();
        }
    }
}
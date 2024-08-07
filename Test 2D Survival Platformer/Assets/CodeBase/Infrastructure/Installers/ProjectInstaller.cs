﻿using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.StaticData;
using CodeBase.UI.Services.LoadingScreen;
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
            
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<ILoadingScreenService>().To<LoadingScreenService>().AsSingle();
            
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<InitializationState>().AsSingle();
            Container.Bind<SceneLoadingState>().AsSingle();
        }
    }
}
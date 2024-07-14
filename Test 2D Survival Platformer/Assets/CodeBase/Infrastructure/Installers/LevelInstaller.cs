using CodeBase.Gameplay.Services.ProjectilesSpawner;
using CodeBase.Infrastructure.Bootstrappers;
using CodeBase.Infrastructure.Factories.CameraFactory;
using CodeBase.Infrastructure.Factories.CharacterFactory;
using CodeBase.Infrastructure.Factories.ProjectileFactory;
using CodeBase.Infrastructure.Services.CameraProvider;
using CodeBase.Infrastructure.Services.CharacterProvider;
using CodeBase.Infrastructure.Services.InputService;
using CodeBase.Infrastructure.Services.ProjectilePool;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.UI.Services.UIFactory;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBootstrapper();
            BindFactories();
            BindServices();
            BindStates();
        }

        private void BindBootstrapper() => 
            Container.BindInterfacesTo<LevelBootstrapper>().AsSingle();

        private void BindFactories()
        {
            Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

            Container.Bind<ICharacterProvider>().To<CharacterProvider>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();

            Container.Bind<IProjectilesSpawner>().To<ProjectilesSpawner>().AsSingle();
            Container.Bind<IProjectilePool>().To<ProjectilePool>().AsSingle();
        }

        private void BindStates()
        {
            Container.Bind<WorldSpawningState>().AsSingle();
            Container.Bind<GameplayState>().AsSingle();
            Container.Bind<RestartState>().AsSingle();
        }
    }
}
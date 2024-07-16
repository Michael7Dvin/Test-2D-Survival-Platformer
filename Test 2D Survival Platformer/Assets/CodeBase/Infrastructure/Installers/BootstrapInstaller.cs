using CodeBase.Infrastructure.Bootstrappers;
using CodeBase.UI.Services.LoadingScreen;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AppBootstrapper>().AsSingle();
        }
    }
}

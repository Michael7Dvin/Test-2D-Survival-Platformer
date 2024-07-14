using CodeBase.Infrastructure.Bootstrappers;
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

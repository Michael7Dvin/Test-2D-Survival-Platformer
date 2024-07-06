using CodeBase.Infrastructure.Services.SceneLoader;

namespace CodeBase.Infrastructure.Services.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(SceneAddresses sceneAddresses)
        {
            SceneAddresses = sceneAddresses;
        }

        public SceneAddresses SceneAddresses { get; }
    }
}
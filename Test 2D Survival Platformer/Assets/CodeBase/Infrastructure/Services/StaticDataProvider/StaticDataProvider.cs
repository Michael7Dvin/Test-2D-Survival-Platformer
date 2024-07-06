using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.CharacterFactory;
using CodeBase.Infrastructure.Services.SceneLoader;

namespace CodeBase.Infrastructure.Services.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(SceneAddresses sceneAddresses, PrefabAddresses prefabAddresses, GameConfig gameConfig)
        {
            SceneAddresses = sceneAddresses;
            PrefabAddresses = prefabAddresses;
            GameConfig = gameConfig;
        }

        public SceneAddresses SceneAddresses { get; }
        public PrefabAddresses PrefabAddresses { get; }
        public GameConfig GameConfig { get; }
    }
}
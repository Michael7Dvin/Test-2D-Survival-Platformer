using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.CharacterFactory;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(SceneAddresses sceneAddresses,
            PrefabAddresses prefabAddresses,
            CharacterConfig characterConfig)
        {
            SceneAddresses = sceneAddresses;
            PrefabAddresses = prefabAddresses;
            CharacterConfig = characterConfig;
        }

        public SceneAddresses SceneAddresses { get; }
        public PrefabAddresses PrefabAddresses { get; }
        public CharacterConfig CharacterConfig { get; }
    }
}
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(SceneAddresses sceneAddresses,
            PrefabAddresses prefabAddresses,
            CharacterConfig characterConfig, 
            ProjectilesConfig projectilesConfig)
        {
            SceneAddresses = sceneAddresses;
            PrefabAddresses = prefabAddresses;
            CharacterConfig = characterConfig;
            ProjectilesConfig = projectilesConfig;
        }

        public SceneAddresses SceneAddresses { get; }
        public PrefabAddresses PrefabAddresses { get; }
        public CharacterConfig CharacterConfig { get; }
        public ProjectilesConfig ProjectilesConfig { get; }
    }
}
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(SceneAddresses sceneAddresses,
            PrefabAddresses prefabAddresses,
            CharacterConfig characterConfig, 
            ProjectileConfig projectileConfig,
            ProjectileSpawnerConfig projectileSpawnerConfig)
        {
            SceneAddresses = sceneAddresses;
            PrefabAddresses = prefabAddresses;
            CharacterConfig = characterConfig;
            ProjectileConfig = projectileConfig;
            ProjectileSpawnerConfig = projectileSpawnerConfig;
        }

        public SceneAddresses SceneAddresses { get; }
        public PrefabAddresses PrefabAddresses { get; }
        public CharacterConfig CharacterConfig { get; }
        public ProjectileConfig ProjectileConfig { get; }
        public ProjectileSpawnerConfig ProjectileSpawnerConfig { get; }
    }
}
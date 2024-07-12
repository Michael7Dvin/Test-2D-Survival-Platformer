using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.StaticDataProvider
{
    public interface IStaticDataProvider
    {
        SceneAddresses SceneAddresses { get; }
        PrefabAddresses PrefabAddresses { get; }
        CharacterConfig CharacterConfig { get; }
        ProjectileConfig ProjectileConfig { get; }
        ProjectileSpawnerConfig ProjectileSpawnerConfig { get; }
    }
}
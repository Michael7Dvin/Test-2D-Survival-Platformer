using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.CharacterFactory;
using CodeBase.Infrastructure.Services.SceneLoader;

namespace CodeBase.Infrastructure.Services.StaticDataProvider
{
    public interface IStaticDataProvider
    {
        SceneAddresses SceneAddresses { get; }
        PrefabAddresses PrefabAddresses { get; }
        GameConfig GameConfig { get; }
    }
}
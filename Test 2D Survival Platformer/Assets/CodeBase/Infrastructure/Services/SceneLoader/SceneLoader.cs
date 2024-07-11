using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.StaticData;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader 
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly SceneAddresses _sceneAddresses;

        public SceneLoader(IAddressablesLoader addressablesLoader, IStaticDataProvider staticDataProvider)
        {
            _addressablesLoader = addressablesLoader;
            _sceneAddresses = staticDataProvider.SceneAddresses;
        }

        public async UniTask LoadGameLevel()
        {
            await _addressablesLoader.LoadSceneAsync(_sceneAddresses.GameLevel);
        }
    }
}
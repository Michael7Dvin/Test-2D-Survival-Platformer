using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader
{
    public interface IAddressablesLoader
    {
        UniTask<GameObject> LoadGameObjectAsync(AssetReferenceGameObject assetReference);
        UniTask LoadSceneAsync(AssetReference sceneReference);
    }
}
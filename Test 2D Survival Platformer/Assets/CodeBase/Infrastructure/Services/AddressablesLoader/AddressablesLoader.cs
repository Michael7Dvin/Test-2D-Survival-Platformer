using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace CodeBase.Infrastructure.Services.AddressablesLoader
{
    public class AddressablesLoader : IAddressablesLoader
    {
        public UniTask<GameObject> LoadGameObjectAsync(AssetReferenceGameObject assetReference)
        {
            throw new System.NotImplementedException();
        }

        public async UniTask LoadSceneAsync(AssetReference sceneReference)
        {
            if (sceneReference.RuntimeKeyIsValid() == false)
            {
                Debug.LogError($"Unable to load scene. {nameof(AssetReference)} is null");
                return;
            }
            
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(sceneReference);
            await handle.Task;
            Debug.Log($"Scene loaded: {handle.Result.Scene.name}"); 
        }
    }
}
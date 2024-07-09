using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace CodeBase.Infrastructure.Services.AddressablesLoader
{
    public class AddressablesLoader : IAddressablesLoader
    {
        private readonly Dictionary<string, AsyncOperationHandle> _cachedAssets = new();
        
        public async UniTask<GameObject> LoadGameObjectAsync(AssetReferenceGameObject assetReference)
        {
            if (assetReference.RuntimeKeyIsValid() == false)
            {
                Debug.LogError($"Unable to load GameObject. AssetReference is null");
                return null;
            }

            string assetID = assetReference.AssetGUID;
            
            if (_cachedAssets.TryGetValue(assetID, out AsyncOperationHandle cachedHandle))
                return (GameObject) cachedHandle.Result;

            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(assetReference);
            await handle.Task;
            _cachedAssets.Add(assetID, handle);
            return handle.Result;
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
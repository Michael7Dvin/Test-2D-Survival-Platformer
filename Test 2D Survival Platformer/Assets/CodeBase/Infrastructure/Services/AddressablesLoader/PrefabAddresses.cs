using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Prefabs", fileName = "PrefabAddresses")]
    public class PrefabAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Character { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject CharacterHealth { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject Canvas { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject EventSystem { get; private set; }
    }
}
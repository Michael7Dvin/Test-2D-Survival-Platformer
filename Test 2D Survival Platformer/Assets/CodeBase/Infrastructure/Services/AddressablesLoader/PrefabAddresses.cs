using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Prefabs", fileName = "PrefabAddresses")]
    public class PrefabAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Character { get; private set; }
    }
}
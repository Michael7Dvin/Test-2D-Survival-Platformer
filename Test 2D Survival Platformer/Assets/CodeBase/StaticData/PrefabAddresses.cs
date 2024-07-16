using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Prefabs", fileName = "PrefabAddresses")]
    public class PrefabAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Character { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject Camera { get; private set; }
        
        
        [field: SerializeField] public AssetReferenceGameObject Projectile { get; private set; }

        [field: SerializeField] public AssetReferenceGameObject Canvas { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject EventSystem { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject CharacterHealth { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject DeathWindowView { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject LoadingScreen { get; private set; }
    }
}
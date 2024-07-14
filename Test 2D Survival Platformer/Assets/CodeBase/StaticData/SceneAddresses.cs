using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Scenes", fileName = "SceneAddresses")]
    public class SceneAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReference GameLevel { get; private set; }
    }
}
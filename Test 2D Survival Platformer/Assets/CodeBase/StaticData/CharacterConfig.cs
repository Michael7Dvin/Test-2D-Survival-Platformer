using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3 SpawnPoint { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
        
        [field: SerializeField] public float VanishDurationInSeconds { get; private set; }
        [field: SerializeField] public float VanishFadeAnimationDurationInSeconds { get; private set; }
        [field: SerializeField] public float VanishCooldownInSeconds { get; private set; }
    }
}
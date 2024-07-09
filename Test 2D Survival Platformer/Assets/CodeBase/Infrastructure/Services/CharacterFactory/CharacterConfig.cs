using UnityEngine;

namespace CodeBase.Infrastructure.Services.CharacterFactory
{
    [CreateAssetMenu(menuName = "StaticData/Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3 SpawnPoint { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
    }
}
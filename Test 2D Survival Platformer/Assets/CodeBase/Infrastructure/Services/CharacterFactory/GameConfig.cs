using UnityEngine;

namespace CodeBase.Infrastructure.Services.CharacterFactory
{
    [CreateAssetMenu(menuName = "StaticData/Configs/Game", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}
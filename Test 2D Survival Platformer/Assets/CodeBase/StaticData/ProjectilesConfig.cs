using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Configs/Projectiles", fileName = "ProjectilesConfig")]
    public class ProjectilesConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
    }
}
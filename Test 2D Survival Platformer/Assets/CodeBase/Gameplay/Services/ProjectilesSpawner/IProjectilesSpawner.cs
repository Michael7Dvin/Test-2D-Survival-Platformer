using CodeBase.Gameplay.Character;
using UnityEngine;

namespace CodeBase.Gameplay.Services.ProjectilesSpawner
{
    public interface IProjectilesSpawner
    {
        void Initialize(Camera camera, ICharacter character);
    }
}
using CodeBase.Gameplay.Character;
using UnityEngine;

namespace CodeBase.Gameplay.Services.ProjectilesSpawner
{
    public interface IProjectilesSpawner
    {
        void Enable(Camera camera, ICharacter character);
        void Disable();
    }
}
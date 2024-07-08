using UnityEngine;

namespace CodeBase.Gameplay.Character.Movement
{
    public interface IMover
    {
        void Move(Vector2 direction, float deltaTime);
    }
}
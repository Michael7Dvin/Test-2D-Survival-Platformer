using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Character.Movement
{
    public interface IMover
    {
        IReadOnlyReactiveProperty<bool> IsMoving { get; }
        void Move(Vector2 direction, float deltaTime);
    }
}
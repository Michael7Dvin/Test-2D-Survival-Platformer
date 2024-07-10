using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Character.Movement
{
    public interface IMover
    {
        bool Enabled { set; }
        IReadOnlyReactiveProperty<bool> IsMoving { get; }
        
        void Move(Vector2 direction, float deltaTime);
    }
}
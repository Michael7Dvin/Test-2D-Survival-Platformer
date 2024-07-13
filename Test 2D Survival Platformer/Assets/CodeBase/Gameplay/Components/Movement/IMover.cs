﻿using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Components.Movement
{
    public interface IMover
    {
        bool Enabled { set; }
        IReadOnlyReactiveProperty<bool> IsMoving { get; }
        
        void Move(Vector2 direction, float deltaTime);
    }
}
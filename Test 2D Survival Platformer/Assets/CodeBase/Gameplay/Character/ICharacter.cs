﻿using CodeBase.Gameplay.Components.Animator;
using CodeBase.Gameplay.Components.Death;
using CodeBase.Gameplay.Components.Healths;
using CodeBase.Gameplay.Components.Movement;
using UnityEngine;

namespace CodeBase.Gameplay.Character
{
    public interface ICharacter
    {
        GameObject GameObject { get; }
        IDamageable Damageable { get; }
        IHealth Health { get; }
        IDieable Dieable { get; }
        IMover Mover { get; }

        void Construct(IMover mover, IHealth health, IDamageable damageable, IDieable dieable, ICharacterAnimator animator);
        void Initialize();
    }
}
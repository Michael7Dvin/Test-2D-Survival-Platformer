using CodeBase.Gameplay.Character.CharacterAnimation;
using CodeBase.Gameplay.Character.Death;
using CodeBase.Gameplay.Character.Healths;
using CodeBase.Gameplay.Character.Movement;
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
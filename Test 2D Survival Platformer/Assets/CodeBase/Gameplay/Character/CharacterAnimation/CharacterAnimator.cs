using CodeBase.Gameplay.Character.Death;
using CodeBase.Gameplay.Character.Movement;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Character.CharacterAnimation
{
    public class CharacterAnimator : ICharacterAnimator
    {
        private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        private readonly int _dieHash = Animator.StringToHash("Die");

        private readonly Animator _animator;
        private readonly IMover _mover;
        private readonly IDieable _dieable;

        public CharacterAnimator(Animator animator, IMover mover, IDieable dieable)
        {
            _animator = animator;
            _mover = mover;
            _dieable = dieable;
        }

        public void Initialize()
        {
            _mover.IsMoving
                .Subscribe(isMoving => _animator.SetBool(_isMovingHash, isMoving))
                .AddTo(_animator.gameObject);

            _dieable.Died
                .Subscribe(_ => _animator.SetTrigger(_dieHash))
                .AddTo(_animator.gameObject);
        }
    }
}
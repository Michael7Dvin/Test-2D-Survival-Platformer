using CodeBase.Gameplay.Character.Movement;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Character.CharacterAnimation
{
    public class CharacterAnimator : ICharacterAnimator
    {
        private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        
        private readonly IMover _mover;
        private readonly Animator _animator;
        
        public CharacterAnimator(IMover mover, Animator animator)
        {
            _mover = mover;
            _animator = animator;
        }

        public void Initialize()
        {
            _mover.IsMoving
                .Subscribe(isMoving => _animator.SetBool(_isMovingHash, isMoving))
                .AddTo(_animator.gameObject);
        }
    }
}
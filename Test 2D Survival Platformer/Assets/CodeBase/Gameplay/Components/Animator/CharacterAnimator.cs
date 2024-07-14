using CodeBase.Gameplay.Components.Death;
using CodeBase.Gameplay.Components.Movement;
using UniRx;

namespace CodeBase.Gameplay.Components.Animator
{
    public class CharacterAnimator : ICharacterAnimator
    {
        private readonly int _isMovingHash = UnityEngine.Animator.StringToHash("IsMoving");
        private readonly int _isDeadHash = UnityEngine.Animator.StringToHash("IsDead");

        private readonly UnityEngine.Animator _animator;
        private readonly IMover _mover;
        private readonly IDieable _dieable;

        public CharacterAnimator(UnityEngine.Animator animator, IMover mover, IDieable dieable)
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

            _dieable.IsDead
                .Subscribe(isDead => _animator.SetBool(_isDeadHash, isDead))
                .AddTo(_animator.gameObject);
        }
    }
}
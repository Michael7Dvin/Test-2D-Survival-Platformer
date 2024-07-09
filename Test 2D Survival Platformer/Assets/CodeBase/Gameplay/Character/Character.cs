using CodeBase.Gameplay.Character.CharacterAnimation;
using CodeBase.Gameplay.Character.Death;
using CodeBase.Gameplay.Character.Healths;
using CodeBase.Gameplay.Character.Movement;
using CodeBase.Infrastructure.Services.InputService;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Character
{
    public class Character : MonoBehaviour
    {
        [Inject] private readonly IInputService _inputService;
            
        private IMover _mover;
        private IDieable _dieable;
        private ICharacterAnimator _animator;

        public void Construct(IMover mover,
            IHealth health,
            IDamageable damageable,
            IDieable dieable,
            ICharacterAnimator animator)
        {
            _mover = mover;
            Health = health;
            Damageable = damageable;
            _dieable = dieable;
            _animator = animator;
        }
        
        public IDamageable Damageable { get; private set; }
        public IHealth Health { get; private set; }

        public void Initialize()
        {
            Health.CurrentHealth
                .Where(health => health <= 0)
                .Subscribe(_ => _dieable.Die())
                .AddTo(this);

            _inputService.HorizontalMoveInput
                .Subscribe(horizontalMoveInput =>
                {
                    _mover.Move(new Vector2(horizontalMoveInput, 0), Time.fixedDeltaTime);
                })
                .AddTo(this);

        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Q))
                Damageable.TakeDamage(100f);
        }
    }
}
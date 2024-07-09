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

        public void Construct(IMover mover, IHealth health, IDamageable damageable, IDieable dieable)
        {
            _mover = mover;
            Health = health;
            Damageable = damageable;
            _dieable = dieable;
        }
        
        public IDamageable Damageable { get; private set; }
        public IHealth Health { get; private set; }

        public void Initialize()
        {
            Health.CurrentHealth
                .Where(health => health <= 0)
                .Subscribe(_ => _dieable.Die())
                .AddTo(this);
        }

        private void FixedUpdate() => 
            _mover.Move(new Vector2(_inputService.HorizontalMoveInput.Value, 0), Time.fixedDeltaTime);
    }
}
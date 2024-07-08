using CodeBase.Gameplay.Character.Death;
using CodeBase.Gameplay.Character.Healths;
using CodeBase.Gameplay.Character.Movement;
using CodeBase.Infrastructure.Services.InputService;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Character
{
    public class Character : MonoBehaviour
    {
        [Inject] private readonly IInputService _inputService;
            
        private IMover _mover;
        private IHealth _health;
        private IDamageable _damageable;
        private IDieable _dieable;

        public void Construct(IMover mover, IHealth health, IDamageable damageable, IDieable dieable)
        {
            _mover = mover;
            _health = health;
            _damageable = damageable;
            _dieable = dieable;
        }

        public async void Initialize()
        {
            _inputService.HorizontalMoveInput
                .Subscribe(xAxis => _mover.Move(new Vector2(xAxis, 0), Time.deltaTime))
                .AddTo(this);
            
            _health.CurrentHealth
                .Where(health => health <= 0)
                .Subscribe(_ => _dieable.Die())
                .AddTo(this);

            await UniTask.Delay(2000);
            
            _damageable.TakeDamage(1000);
        }
    }
}
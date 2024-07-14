﻿using CodeBase.Gameplay.Components.Animator;
using CodeBase.Gameplay.Components.Death;
using CodeBase.Gameplay.Components.Healths;
using CodeBase.Gameplay.Components.Movement;
using CodeBase.Infrastructure.Services.InputService;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Character
{
    public class Character : MonoBehaviour, ICharacter
    {
        [Inject] private readonly IInputService _inputService;

        private ICharacterAnimator _animator;

        public void Construct(IMover mover,
            IHealth health,
            IDamageable damageable,
            IDieable dieable,
            ICharacterAnimator animator)
        {
            Mover = mover;
            Health = health;
            Damageable = damageable;
            Dieable = dieable;
            _animator = animator;
        }
        
        public GameObject GameObject => gameObject;
        public IMover Mover { get; private set; }
        public IDamageable Damageable { get; private set; }
        public IHealth Health { get; private set; }
        public IDieable Dieable { get; private set; }


        public void Initialize()
        {
            Health.CurrentHealth
                .Where(health => health <= 0)
                .Subscribe(_ => Dieable.Die())
                .AddTo(this);

            _inputService.HorizontalMoveInput
                .Subscribe(horizontalMoveInput =>
                {
                    Vector2 moveDirection = new Vector2(horizontalMoveInput, 0);
                    Mover.Move(moveDirection, Time.fixedDeltaTime);
                })
                .AddTo(this);
        }
    }
}
using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Components.Vanish
{
    public class Vanish : IVanish
    {
        private readonly float _cooldownInSeconds;
        private readonly Collider2D _damageableCollider;
        
        private readonly Sequence _vanishSequence;
        private readonly UniTask _cooldownDelay;
        private bool _readyToActivate = true;

        public Vanish(float durationInSeconds,
            float cooldownInSeconds,
            float fadeAnimationDurationInSeconds,
            Collider2D damageableCollider,
            SpriteRenderer spriteRenderer)
        {
            _cooldownInSeconds = cooldownInSeconds;
            _damageableCollider = damageableCollider;
            
            Tweener fadeOutTween = spriteRenderer
                .DOFade(0.1f, fadeAnimationDurationInSeconds)
                .SetAutoKill(false)
                .Pause();
            
            Tweener fadeInTween = spriteRenderer
                .DOFade(1f, fadeAnimationDurationInSeconds)
                .SetAutoKill(false)
                .Pause();

            _vanishSequence = DOTween.Sequence()
                .Append(fadeOutTween)
                .AppendInterval(durationInSeconds)
                .Append(fadeInTween)
                .SetAutoKill(false)
                .Pause();
        }

        public bool Enabled { get; set; } = true;

        public bool ReadyToActivate
        {
            get => Enabled == true && _readyToActivate;
            private set => _readyToActivate = value;
        }

        public async UniTaskVoid Activate()
        {
            if (Enabled == false)
                return;
            
            if (ReadyToActivate == false)
            {
                Debug.LogError($"Unable to activate. {nameof(ReadyToActivate)} is false.");
                return;
            }

            ReadyToActivate = false;
            _damageableCollider.enabled = false;
            
            _vanishSequence.Restart();
            await _vanishSequence.AwaitForComplete();
            
            _damageableCollider.enabled = true;

            await UniTask.Delay(TimeSpan.FromSeconds(_cooldownInSeconds));
            ReadyToActivate = true;
        }
    }
}
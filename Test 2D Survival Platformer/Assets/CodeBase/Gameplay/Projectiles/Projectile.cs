using CodeBase.Gameplay.Components.Healths;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Projectiles
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        private float _damage;
        private float _moveSpeed;

        private Tweener _moveTween;
        
        public void Construct(float damage, float moveSpeed)
        {
            _damage = damage;
            _moveSpeed = moveSpeed;

            _moveTween = transform
                .DOMove(Vector2.zero, _moveSpeed)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(() => gameObject.SetActive(false))
                .SetAutoKill(false)
                .Pause();
        }
        
        public GameObject GameObject => gameObject;

        public void Launch(Vector2 targetPosition, float durationInSeconds)
        {
            Vector2 selfPosition = transform.position;
            Vector2 targetDirection = (targetPosition - selfPosition).normalized;
            Vector2 endPosition = selfPosition + targetDirection * durationInSeconds * _moveSpeed;

            _moveTween.ChangeEndValue((Vector3)endPosition, true).Restart();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
                _moveTween.Complete();
                gameObject.SetActive(false);
            }
        }
    }
}
using CodeBase.Gameplay.Components.Healths;
using CodeBase.Infrastructure.Services.ProjectilePool;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Projectiles
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        private IProjectilePool _projectilePool;
        
        private float _damage;
        private float _moveSpeed;

        private Tweener _moveTween;

        [Inject]
        public void InjectDependencies(IProjectilePool projectilePool)
        {
            _projectilePool = projectilePool;
        }
        
        public void Construct(float damage, float moveSpeed)
        {
            _damage = damage;
            _moveSpeed = moveSpeed;

            _moveTween = transform
                .DOMove(Vector2.zero, _moveSpeed)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(() => _projectilePool.Release(this))
                .SetAutoKill(false)
                .Pause();
        }
        
        public GameObject GameObject => gameObject;

        public void Launch(Vector2 targetPosition, float durationInSeconds)
        {
            Vector2 selfPosition = transform.position;
            Vector2 targetDirection = (targetPosition - selfPosition).normalized;
            Vector2 endPosition = selfPosition + targetDirection * durationInSeconds * _moveSpeed;

            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            
            _moveTween.ChangeEndValue((Vector3)endPosition, true).Restart();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
                _moveTween.Pause();
                _projectilePool.Release(this);
            }
        }
    }
}
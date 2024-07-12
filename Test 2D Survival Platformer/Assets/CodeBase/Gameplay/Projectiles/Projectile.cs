using CodeBase.Gameplay.Components.Healths;
using CodeBase.Gameplay.Components.Movement;
using UnityEngine;

namespace CodeBase.Gameplay.Projectiles
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        private float _damage;

        public void Construct(IMover mover, float damage)
        {
            Mover = mover;
            _damage = damage;
        }

        public IMover Mover { get; private set; }
        public GameObject GameObject => gameObject;
        public Transform Target { get; set; }
        private bool HasTarget => Target != null;

        private void FixedUpdate()
        {
            if (HasTarget == true)
            {
                Vector2 direction = (Target.position - transform.position).normalized;
                Mover.Move(direction, Time.fixedDeltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
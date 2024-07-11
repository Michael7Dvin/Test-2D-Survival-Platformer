using System;
using CodeBase.Gameplay.Components.Healths;
using CodeBase.Gameplay.Components.Movement;
using UnityEngine;

namespace CodeBase.Gameplay.Projectiles
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        private IMover _mover;
        private float _damage;

        public void Construct(IMover mover, float damage)
        {
            _mover = mover;
            _damage = damage;
        }
        
        private bool HasTarget => Target != null;
        public Transform Target { get; set; }
        
        private void FixedUpdate()
        {
            if (HasTarget == true)
            {
                Vector2 direction = (Target.position - transform.position).normalized;
                _mover.Move(direction, Time.fixedDeltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
                Destroy(this);
            }
        }
    }
}
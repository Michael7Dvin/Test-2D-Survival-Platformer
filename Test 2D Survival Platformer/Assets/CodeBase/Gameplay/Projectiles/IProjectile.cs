using UnityEngine;

namespace CodeBase.Gameplay.Projectiles
{
    public interface IProjectile
    {
        GameObject GameObject { get; }

        public void Construct(float damage, float moveSpeed);
        void Launch(Vector2 targetPosition, float durationInSeconds);
    }
}
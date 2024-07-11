using CodeBase.Gameplay.Components.Movement;
using UnityEngine;

namespace CodeBase.Gameplay.Projectiles
{
    public interface IProjectile
    {
        Transform Target { get; set; }
        void Construct(IMover mover, float damage);
    }
}
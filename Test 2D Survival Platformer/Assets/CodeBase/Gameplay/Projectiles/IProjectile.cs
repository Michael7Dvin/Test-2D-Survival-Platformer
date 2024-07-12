using CodeBase.Gameplay.Components.Movement;
using UnityEngine;

namespace CodeBase.Gameplay.Projectiles
{
    public interface IProjectile
    {
        GameObject GameObject { get; }
        Transform Target { get; set; }
        IMover Mover { get; }

        void Construct(IMover mover, float damage);
    }
}
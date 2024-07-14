using CodeBase.Gameplay.Projectiles;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Factories.ProjectileFactory
{
    public interface IProjectileFactory
    {
        UniTask Warmup();
        UniTask<IProjectile> Create();
    }
}
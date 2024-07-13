using CodeBase.Gameplay.Projectiles;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.ProjectilePool
{
    public interface IProjectilePool
    {
        UniTask Initialize(int capacity);
        UniTask<IProjectile> Get();
        void Release(IProjectile projectile);
    }
}
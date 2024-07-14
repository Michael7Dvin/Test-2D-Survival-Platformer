using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Projectiles;
using CodeBase.Infrastructure.Factories.ProjectileFactory;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.ProjectilePool
{
    public class ProjectilePool : IProjectilePool
    {
        private readonly IProjectileFactory _projectileFactory;
        
        private List<IProjectile> _projectiles;

        public ProjectilePool(IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
        }

        public async UniTask Initialize(int capacity)
        {
            _projectiles = new List<IProjectile>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                IProjectile projectile = await _projectileFactory.Create();
                projectile.GameObject.SetActive(false);
                _projectiles.Add(projectile);
            }
            
        }

        public async UniTask<IProjectile> Get()
        {
            IProjectile projectile = _projectiles.FirstOrDefault(x => x.GameObject.activeSelf == false);

            if (projectile == null)
            {
                projectile = await Create();
                _projectiles.Add(projectile);
            }
            
            projectile.GameObject.SetActive(true);
            return projectile;
        }

        public void Release(IProjectile projectile) => 
            projectile.GameObject.SetActive(false);

        private async UniTask<IProjectile> Create() => 
            await _projectileFactory.Create();
    }
}
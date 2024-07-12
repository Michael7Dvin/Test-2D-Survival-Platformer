using CodeBase.Gameplay.Components.Movement;
using CodeBase.Gameplay.Projectiles;
using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories.ProjectileFactory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly IInstantiator _instantiator;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly ProjectileConfig _projectileConfig;

        public ProjectileFactory(IAddressablesLoader addressablesLoader,
            IInstantiator instantiator,
            IStaticDataProvider staticDataProvider)
        {
            _addressablesLoader = addressablesLoader;
            _instantiator = instantiator;
            _prefabAddresses = staticDataProvider.PrefabAddresses;
            _projectileConfig = staticDataProvider.ProjectileConfig;
        }

        public async UniTask Warmup() => 
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Projectile);

        public async UniTask<IProjectile> Create()
        {
            GameObject projectilePrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Projectile);
            GameObject projectileGameObject = _instantiator.InstantiatePrefab(projectilePrefab);
            
            IProjectile projectile = projectileGameObject.GetComponent<IProjectile>();
            Rigidbody2D rigidbody = projectileGameObject.GetComponent<Rigidbody2D>();
            
            IMover mover = new ProjectileMover(_projectileConfig.MoveSpeed, rigidbody);
            
            projectile.Construct(mover, _projectileConfig.Damage);
            
            return projectile;
        }
    }
}
using System;
using CodeBase.Gameplay.Character;
using CodeBase.Gameplay.Projectiles;
using CodeBase.Infrastructure.Services.ProjectilePool;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Gameplay.Services.ProjectilesSpawner
{
    public class ProjectilesSpawner : IProjectilesSpawner, IDisposable
    {
        private readonly IProjectilePool _projectilePool;
        private readonly float _borderMargin;
        private readonly float _spawnIntervalInSeconds;
        private readonly CompositeDisposable _compositeDisposable = new();
        
        private Camera _camera;
        private ICharacter _character;

        public ProjectilesSpawner(IProjectilePool projectilePool, IStaticDataProvider staticDataProvider)
        {
            _projectilePool = projectilePool;
            _borderMargin = staticDataProvider.ProjectileSpawnerConfig.ScreenBorderSpawnMargin;
            _spawnIntervalInSeconds = staticDataProvider.ProjectileSpawnerConfig.SpawnIntervalInSeconds;
        }

        public void Initialize(Camera camera, ICharacter character)
        {
            _camera = camera;
            _character = character;
            
            Observable.Interval(TimeSpan.FromSeconds(_spawnIntervalInSeconds))
                .Subscribe(_ => Spawn().Forget())
                .AddTo(_compositeDisposable);
        }



        private async UniTaskVoid Spawn()
        {
            Vector2 spawnPosition = GetRandomPointOutsideScreen();
            Vector2 targetPosition = _character.GameObject.transform.position;
            
            IProjectile projectile = await _projectilePool.Get();
            projectile.GameObject.transform.position = spawnPosition;
            projectile.Launch(targetPosition, 10f);
        }
        
        private Vector2 GetRandomPointOutsideScreen()
        {
            Vector2 screenBottomLeft = _camera.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 screenTopRight = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            float minX = screenBottomLeft.x - _borderMargin;
            float maxX = screenTopRight.x + _borderMargin;
            float minY = screenBottomLeft.y - _borderMargin;
            float maxY = screenTopRight.y + _borderMargin;

            int side = Random.Range(0, 3); // 0 = left, 1 = right, 2 = top

            float x = 0f;
            float y = 0f;

            switch (side)
            {
                case 0: // Left
                    x = minX;
                    y = Random.Range(minY, maxY);
                    break;
                case 1: // Right
                    x = maxX;
                    y = Random.Range(minY, maxY);
                    break;
                case 2: // Top
                    x = Random.Range(minX, maxX);
                    y = maxY;
                    break;
            }

            y = Mathf.Max(y, screenBottomLeft.y);

            return new Vector2(x, y);
        }

        public void Dispose() => 
            _compositeDisposable?.Dispose();
    }
}
using Cinemachine;
using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories.CameraFactory
{
    public class CameraFactory : ICameraFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly IInstantiator _instantiator;
        private readonly PrefabAddresses _prefabAddresses;

        public CameraFactory(IAddressablesLoader addressablesLoader,
            IInstantiator instantiator,
            IStaticDataProvider staticDataProvider)
        {
            _addressablesLoader = addressablesLoader;
            _instantiator = instantiator;
            _prefabAddresses = staticDataProvider.PrefabAddresses;
        }

        public async UniTask WarmUp() => 
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Camera);

        public async UniTask<Camera> Create(Transform followPoint)
        {
            GameObject cameraPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Camera);
            GameObject cameraGameObject = _instantiator.InstantiatePrefab(cameraPrefab);

            Camera camera = cameraGameObject.GetComponentInChildren<Camera>();
            
            CinemachineVirtualCamera virtualCamera = cameraGameObject.GetComponentInChildren<CinemachineVirtualCamera>();
            virtualCamera.Follow = followPoint;
            virtualCamera.LookAt = followPoint;

            return camera;
        }
    }
}
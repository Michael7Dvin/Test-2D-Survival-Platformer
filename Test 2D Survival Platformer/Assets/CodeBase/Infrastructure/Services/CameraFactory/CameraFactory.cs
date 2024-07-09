using Cinemachine;
using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.CameraFactory
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

        public async UniTask Create(Transform followPoint)
        {
            GameObject cameraPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Camera);
            GameObject cameraGameObject = _instantiator.InstantiatePrefab(cameraPrefab);

            CinemachineVirtualCamera virtualCamera = cameraGameObject.GetComponentInChildren<CinemachineVirtualCamera>();
            virtualCamera.Follow = followPoint;
            virtualCamera.LookAt = followPoint;
        }
    }
}
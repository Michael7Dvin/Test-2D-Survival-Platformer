using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.StaticData;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Services.LoadingScreen
{
    public class LoadingScreenService : ILoadingScreenService
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly IInstantiator _instantiator;
        private readonly PrefabAddresses _prefabAddresses;
        
        private LoadingScreenView _loadingScreen;
        private Tweener _fadeOutTween;
        
        public LoadingScreenService(IAddressablesLoader addressablesLoader,
            IInstantiator instantiator,
            IStaticDataProvider staticDataProvider)
        {
            _addressablesLoader = addressablesLoader;
            _instantiator = instantiator;
            _prefabAddresses = staticDataProvider.PrefabAddresses;
        }

        public async UniTask Initialize()
        {
            GameObject canvasPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Canvas);
            GameObject canvasGameObject  = _instantiator.InstantiatePrefab(canvasPrefab);
            
            GameObject loadingScreenPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.LoadingScreen);
            GameObject loadingScreenGameObject = _instantiator.InstantiatePrefab(loadingScreenPrefab, canvasGameObject.transform);

            _loadingScreen = loadingScreenGameObject.GetComponent<LoadingScreenView>();

            _fadeOutTween = _loadingScreen.CanvasGroup
                .DOFade(0, 3)
                .SetAutoKill(false)
                .Pause();
        }

        public void Show()
        {
            _loadingScreen.CanvasGroup.alpha = 1;
            _loadingScreen.gameObject.SetActive(true);
        }

        public async UniTask Hide()
        {
            _fadeOutTween.Restart();
            await _fadeOutTween.AwaitForComplete();
            
            _loadingScreen.gameObject.SetActive(false);
        }
    }
}
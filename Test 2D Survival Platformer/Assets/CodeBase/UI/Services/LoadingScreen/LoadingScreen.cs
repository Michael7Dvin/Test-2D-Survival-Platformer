using CodeBase.UI.Services.UIFactory;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.UI.Services.LoadingScreen
{
    public class LoadingScreen : ILoadingScreen
    {
        private readonly IUIFactory _uiFactory;
        private GameObject _loadingScreen;

        public LoadingScreen(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public async UniTask Initialize()
        {
            await _uiFactory.CreateCanvas();
            await _uiFactory.CreateEventSystem(); 
            _loadingScreen = await _uiFactory.CreateLoadingScreen();
        }

        public void Show() => 
            _loadingScreen.SetActive(true);

        public void Hide() => 
            _loadingScreen.SetActive(false);
    }
}
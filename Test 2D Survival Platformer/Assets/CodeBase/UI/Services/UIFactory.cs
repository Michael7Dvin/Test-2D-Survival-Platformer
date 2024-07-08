using CodeBase.Gameplay.Character.Healths;
using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.UI.CharacterHealth;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CodeBase.UI.Services
{
    public class UIFactory : IUIFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly IInstantiator _instantiator;
        private readonly PrefabAddresses _prefabAddresses;
        
        private Canvas _canvas;
        private EventSystem _eventSystem;

        public UIFactory(IAddressablesLoader addressablesLoader,
            IInstantiator instantiator,
            IStaticDataProvider staticDataProvider)
        {
            _addressablesLoader = addressablesLoader;
            _instantiator = instantiator;
            _prefabAddresses = staticDataProvider.PrefabAddresses;
        }

        public async UniTask WarmUp()
        {
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Canvas);
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.EventSystem);
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.CharacterHealth);
        }

        public async UniTask CreateCanvas()
        {
            GameObject canvasPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Canvas);
            GameObject canvasGameObject  = _instantiator.InstantiatePrefab(canvasPrefab);

            _canvas = canvasGameObject.GetComponent<Canvas>();
        }

        public async UniTask CreateEventSystem()
        {
            GameObject eventSystemPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.EventSystem);
            GameObject eventSystemGameObject = _instantiator.InstantiatePrefab(eventSystemPrefab);
            
            _eventSystem = eventSystemGameObject.GetComponent<EventSystem>();
        }

        public async UniTask<CharacterHealthView> CreateCharacterHealthView(IHealth characterHealth)
        {
            if (ValidateCanvasAndEventSystem() == false) 
                return null;

            GameObject characterHealthPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.CharacterHealth);
            GameObject characterHealthGameObject = _instantiator.InstantiatePrefab(characterHealthPrefab, _canvas.transform);
            
            CharacterHealthView characterHealthView = characterHealthGameObject.GetComponent<CharacterHealthView>();
            characterHealthView.Construct(characterHealth);
            characterHealthView.Initialize();

            return characterHealthView;
        }

        private bool ValidateCanvasAndEventSystem()
        {
            if (_canvas == null || _eventSystem == null)
            {
                if (_canvas == null)
                    Debug.LogError($"{nameof(_canvas)} is null");
                
                if (_eventSystem == null) 
                    Debug.LogError($"{nameof(_eventSystem)} is null");

                return false;
            }

            return true;
        }
    }
}
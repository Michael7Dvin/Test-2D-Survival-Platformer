using CodeBase.Gameplay.Character;
using CodeBase.Gameplay.Character.Death;
using CodeBase.Gameplay.Character.Healths;
using CodeBase.Gameplay.Character.Movement;
using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.CharacterFactory
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly IInstantiator _instantiator;
        private readonly CharacterConfig _characterConfig;

        public CharacterFactory(IAddressablesLoader addressablesLoader,
            IStaticDataProvider staticDataProvider,
            IInstantiator instantiator)
        {
            _addressablesLoader = addressablesLoader;
            _prefabAddresses = staticDataProvider.PrefabAddresses;
            _instantiator = instantiator;
            _characterConfig = staticDataProvider.CharacterConfig;
        }

        public async UniTask WarmUp() => 
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Character);

        public async UniTask<Character> Create()
        {
            GameObject characterPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Character);
            
            GameObject characterGameObject = _instantiator.InstantiatePrefab(characterPrefab,
                Vector3.zero,
                Quaternion.identity,
                null);
            
            IMover mover = CreateMover(characterGameObject.GetComponent<Rigidbody2D>());
            CharacterHealth characterHealth = CreateHealth();
            IDieable dieable = CreateDeath(characterGameObject);
            
            Character character = characterGameObject.GetComponent<Character>();
            character.Construct(mover, characterHealth, characterHealth, dieable);
            character.Init();

            return character;
        }
        
        private IMover CreateMover(Rigidbody2D rigidbody) => 
            new Mover(_characterConfig.MoveSpeed, rigidbody);
        
        private CharacterHealth CreateHealth() => 
            new CharacterHealth(_characterConfig.MaxHealth);
        
        private static IDieable CreateDeath(Object characterObject) =>
            new Death(characterObject);
    }
}
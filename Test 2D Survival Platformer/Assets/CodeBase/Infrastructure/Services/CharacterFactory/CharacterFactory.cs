﻿using CodeBase.Gameplay.Character;
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
        private readonly GameConfig _gameConfig;

        public CharacterFactory(IAddressablesLoader addressablesLoader,
            IStaticDataProvider staticDataProvider,
            IInstantiator instantiator)
        {
            _addressablesLoader = addressablesLoader;
            _prefabAddresses = staticDataProvider.PrefabAddresses;
            _instantiator = instantiator;
            _gameConfig = staticDataProvider.GameConfig;
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
            
            Mover mover = CreateMover(characterGameObject.GetComponent<Rigidbody2D>());
            
            Character character = characterGameObject.GetComponent<Character>();
            character.Construct(mover);

            return character;
        }
        
        private Mover CreateMover(Rigidbody2D rigidbody) => 
            new(_gameConfig.MoveSpeed, rigidbody);
    }
}
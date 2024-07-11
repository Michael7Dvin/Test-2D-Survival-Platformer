using CodeBase.Gameplay.Character;
using CodeBase.Gameplay.Components.Animator;
using CodeBase.Gameplay.Components.Death;
using CodeBase.Gameplay.Components.Healths;
using CodeBase.Gameplay.Components.Movement;
using CodeBase.Infrastructure.Services.AddressablesLoader;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.StaticData;
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

        public async UniTask<ICharacter> Create()
        {
            GameObject characterPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Character);
            
            GameObject characterGameObject = _instantiator.InstantiatePrefab(characterPrefab,
                _characterConfig.SpawnPoint,
                Quaternion.identity,
                null);
            
            IMover mover = CreateMover(characterGameObject.GetComponent<Rigidbody2D>());
            CharacterHealth characterHealth = CreateHealth(characterGameObject);
            IDieable dieable = CreateDeath(characterGameObject, mover);
            dieable.Initialize();
            
            ICharacterAnimator animator = CreateAnimator(characterGameObject.GetComponentInChildren<Animator>(), mover, dieable);
            animator.Initialize();
            
            ICharacter character = characterGameObject.GetComponent<ICharacter>();
            character.Construct(mover, characterHealth, characterHealth, dieable, animator);
            character.Initialize();

            return character;
        }
        
        private IMover CreateMover(Rigidbody2D rigidbody) => 
            new CharacterMover(_characterConfig.MoveSpeed, rigidbody);
        
        private CharacterHealth CreateHealth(GameObject characterGameObject)
        {
            CharacterHealth characterHealth = characterGameObject.GetComponentInChildren<CharacterHealth>();    
            characterHealth.Construct(_characterConfig.MaxHealth);
            return characterHealth;
        }

        private static IDieable CreateDeath(GameObject characterGameObject, IMover mover) =>
            new CharacterDeath(characterGameObject, mover);

        private static ICharacterAnimator CreateAnimator(Animator animator, IMover mover, IDieable dieable) => 
            new CharacterAnimator(animator, mover, dieable);
    }
}
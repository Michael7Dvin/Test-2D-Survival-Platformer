using CodeBase.Gameplay.Character;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.CharacterProvider
{
    public class CharacterProvider : ICharacterProvider
    {
        private ICharacter _character;
        
        public void Set(ICharacter character) => 
            _character = character;

        public ICharacter Get()
        {
            if (_character == null)
                Debug.LogError($"Unable to retrieve {nameof(ICharacter)}. {nameof(_character)} is null");

            return _character;
        }
    }
}
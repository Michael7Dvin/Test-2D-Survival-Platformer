using CodeBase.Gameplay.Character;

namespace CodeBase.Infrastructure.Services.CharacterProvider
{
    public interface ICharacterProvider
    {
        void Set(ICharacter character);
        ICharacter Get();
    }
}
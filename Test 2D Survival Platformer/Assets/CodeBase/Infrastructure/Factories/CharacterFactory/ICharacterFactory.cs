using CodeBase.Gameplay.Character;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Factories.CharacterFactory
{
    public interface ICharacterFactory
    {
        UniTask WarmUp();
        UniTask<ICharacter> Create();
    }
}
using CodeBase.Gameplay.Character;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.CharacterFactory
{
    public interface ICharacterFactory
    {
        UniTask WarmUp();
        UniTask<Character> Create();
    }
}
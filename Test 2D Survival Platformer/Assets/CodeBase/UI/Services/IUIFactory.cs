using CodeBase.Gameplay.Character.Healths;
using CodeBase.UI.CharacterHealth;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services
{
    public interface IUIFactory
    {
        UniTask WarmUp();
        UniTask CreateCanvas();
        UniTask CreateEventSystem();
        UniTask<CharacterHealthView> CreateCharacterHealthView(IHealth characterHealth);
    }
}
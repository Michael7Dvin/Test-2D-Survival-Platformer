using CodeBase.Gameplay.Components.Healths;
using CodeBase.UI.CharacterHealth;
using CodeBase.UI.Windows.DeathWindow;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.UIFactory
{
    public interface IUIFactory
    {
        UniTask WarmUp();
        UniTask CreateCanvas();
        UniTask CreateEventSystem();
        
        UniTask<CharacterHealthView> CreateCharacterHealthView(IHealth characterHealth);
        UniTask<DeathWindowView> CreateDeathWindow(bool visible = false);
        
    }
}
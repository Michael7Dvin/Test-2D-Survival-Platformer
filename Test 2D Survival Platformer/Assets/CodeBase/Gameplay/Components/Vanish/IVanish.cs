using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.Components.Vanish
{
    public interface IVanish
    {
        bool ReadyToActivate { get; }
        UniTaskVoid Activate();
    }
}
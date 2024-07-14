using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.Components.Vanish
{
    public interface IVanish
    {
        bool Enabled { set; }
        bool ReadyToActivate { get; }
        UniTaskVoid Activate();
    }
}
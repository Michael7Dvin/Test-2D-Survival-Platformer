using Cysharp.Threading.Tasks;
using UniRx;

namespace CodeBase.Gameplay.Components.Death
{
    public interface IDieable
    {
        IReadOnlyReactiveProperty<bool> IsDead { get; }

        void Initialize();
        UniTaskVoid Die();
        void AbortDeath();
    }
}
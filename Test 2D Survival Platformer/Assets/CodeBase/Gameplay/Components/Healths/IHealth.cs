using UniRx;

namespace CodeBase.Gameplay.Components.Healths
{
    public interface IHealth
    {
        float MaxHealth { get; }
        IReadOnlyReactiveProperty<float> CurrentHealth { get; }
        
        void ResetToMaxHealth();
    }
}
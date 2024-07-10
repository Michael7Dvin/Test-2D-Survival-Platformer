using UniRx;

namespace CodeBase.Gameplay.Character.Healths
{
    public interface IHealth
    {
        float MaxHealth { get; }
        IReadOnlyReactiveProperty<float> CurrentHealth { get; }
        
        void ResetToMaxHealth();
    }
}
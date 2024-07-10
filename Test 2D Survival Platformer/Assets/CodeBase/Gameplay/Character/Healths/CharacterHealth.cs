using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Character.Healths
{
    public class CharacterHealth : IHealth, IDamageable
    {
        private readonly ReactiveProperty<float> _currentHealth = new();

        public CharacterHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
            _currentHealth.Value = MaxHealth;
        }

        public float MaxHealth { get; }
        public IReadOnlyReactiveProperty<float> CurrentHealth => _currentHealth;
        
        public void ResetToMaxHealth() => 
            _currentHealth.Value = MaxHealth;

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
            {
                Debug.LogError($"{nameof(damage)} must be more than 0. Damage: {damage}");
                return;                 
            }

            _currentHealth.Value = Mathf.Clamp(_currentHealth.Value - damage, 0, MaxHealth);
        }
    }
}
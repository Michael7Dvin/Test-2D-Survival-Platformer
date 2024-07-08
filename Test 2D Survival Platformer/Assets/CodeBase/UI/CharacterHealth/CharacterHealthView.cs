using CodeBase.Gameplay.Character.Healths;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.CharacterHealth
{
    public class CharacterHealthView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private IHealth _health;

        public void Construct(IHealth health)
        {
            _health = health;
        }

        public void Initialize()
        {
            _health.CurrentHealth
                .Subscribe(health => _image.fillAmount = health / _health.MaxHealth)
                .AddTo(this);
        }
    }
}
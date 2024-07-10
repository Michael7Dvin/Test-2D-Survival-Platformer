using System.Threading.Tasks;
using CodeBase.Gameplay.Character.Healths;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.CharacterHealth
{
    public class CharacterHealthView : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;
        private IHealth _health;

        private bool _isAnimationPlaying;
        private Sequence _fadeSequence;
        private Tweener _fillAmountTweener;

        public void Construct(IHealth health)
        {
            _health = health;
        }

        public void Initialize()
        {
            CreateTweens();

            SubscribeOnHealthIncreased();
            SubscribeOnHealthDecreased();
        }

        private void SubscribeOnHealthDecreased()
        {
            _health.CurrentHealth
                .Pairwise()
                .Where(pair => pair.Current < pair.Previous)
                .Select(pair => pair.Current)
                .Subscribe(_ => OnDamaged().Forget())
                .AddTo(this);
        }
        
        private void SubscribeOnHealthIncreased()
        {
            _health.CurrentHealth
                .Pairwise()
                .Where(pair => pair.Current > pair.Previous)
                .Select(pair => pair.Current)
                .Subscribe(_ => OnHealed().Forget())
                .AddTo(this);
        }

        private void CreateTweens()
        {
            _fadeSequence = DOTween.Sequence()
                .Append(_fillImage.DOFade(0.5f, 0.1f))
                .Append(_fillImage.DOFade(1f, 0.1f))
                .SetAutoKill(false)
                .SetUpdate(true)
                .Pause();
            
            _fillAmountTweener = _fillImage
                .DOFillAmount(1f, 0.2f)
                .SetAutoKill(false)
                .SetUpdate(true)
                .Pause();
        }

        private async UniTaskVoid OnHealed()
        {
            await RestartFillAmountTweener();
        }

        private async UniTaskVoid OnDamaged()
        {
            _fadeSequence.Restart();
            await _fadeSequence.AwaitForComplete();
            
            await RestartFillAmountTweener();
        }

        private async Task RestartFillAmountTweener()
        {
            UpdateFillAmountTweenValues();
            _fillAmountTweener.Restart();
            await _fillAmountTweener.AwaitForComplete();
        }

        private void UpdateFillAmountTweenValues()
        {
            float targetFillAmount = _health.CurrentHealth.Value / _health.MaxHealth;
            _fillAmountTweener.ChangeStartValue(_fillImage.fillAmount).ChangeEndValue(targetFillAmount);
        }
    }
}
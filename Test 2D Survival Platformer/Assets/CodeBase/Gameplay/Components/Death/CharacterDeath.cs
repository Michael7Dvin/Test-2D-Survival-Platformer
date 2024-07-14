using CodeBase.Gameplay.Components.Movement;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Components.Death
{
    public class CharacterDeath : IDieable 
    {
        private readonly ReactiveProperty<bool> _isDead = new();
        private readonly GameObject _characterGameObject;
        private readonly IMover _characterMover;

        private Tweener _shrinkTweener;

        public CharacterDeath(GameObject characterGameObject, IMover characterMover)
        {
            _characterGameObject = characterGameObject;
            _characterMover = characterMover;
        }

        public IReadOnlyReactiveProperty<bool> IsDead => _isDead;

        public void Initialize()
        {
            _shrinkTweener = _characterGameObject.transform
                .DOScale(new Vector3(0.5f, 0.5f), 2f)
                .SetAutoKill(false)
                .Pause();
        }

        public async UniTaskVoid Die()
        {
            _characterMover.Enabled = false;
            
            Vector3 currentScale = _characterGameObject.transform.localScale;
            float targetScaleX = Mathf.Sign(currentScale.x) * 0.5f;

            _shrinkTweener
                .ChangeStartValue(currentScale)
                .ChangeEndValue(new Vector3(targetScaleX,0.5f))
                .Restart();
            
            await _shrinkTweener.AwaitForComplete();

            _isDead.Value = true;
        }

        public void AbortDeath()
        {
            _characterGameObject.transform.localScale = Vector3.one;
            _isDead.Value = false;
        }
    }
}